using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bu sınıf zaman sayacını kontrol ediyor
public class TimeScript : MonoBehaviour
{
    public static float timeValue;

    private Text _timerText;
    private GameObject _gm;
    private bool _timesUp = false;
    
    void Start()
    {
        _timerText = GetComponent<Text>();
        _gm = GameObject.Find("GameManager");
        timeValue = 150;
    }
    
    void Update()
    {
        // Zaman sayacını yazan karar yapısı
        if (timeValue >= 0 && !_timesUp)
        {
            _timerText.text = "\n\nTIME\n" + timeValue.ToString("0");
        }
        // Zaman sayacı 0a vurursa oyun bitiriliyor
        else
        {
            PlayerMovement.cylinderIn = false;
            _gm.transform.GetComponent<GameManager>().GameEnd(false);
            _timesUp = true;
        }
        timeValue -= Time.deltaTime;
    }
}
