using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bu sınıfta skor değişimi yapılıyor
public class Score : MonoBehaviour
{
    public static int scoreValue;
    Text score;
    
    void Start()
    {
        score = GetComponent<Text>();
        scoreValue = 0;
    }
    
    void Update()
    {
        score.text = "\n\nScore\n" + scoreValue;
    }
}
