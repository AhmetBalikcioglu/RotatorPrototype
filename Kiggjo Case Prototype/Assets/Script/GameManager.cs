using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu fonksiyon oyun içi elementleri kontrol ediyor
public class GameManager : MonoBehaviour
{
    public static bool disksCleared;
    public static bool smallDisksCleared;
    public GameObject bombImage;
    public GameObject broom;

    private GameObject[] _disksInScene;
    private GameObject _player;
    private GameObject _uiController;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _uiController = GameObject.Find("Canvas");
        disksCleared = false;
        smallDisksCleared = false;
        Physics.IgnoreLayerCollision(8, 9, true);
    }

    void Update()
    {
        // Disklerin hepsi kırıldı ise temizlenme safhasına geçiş yapılıyor
        if (!disksCleared)
        {
            _disksInScene = GameObject.FindGameObjectsWithTag("Disk");
            if (_disksInScene.Length == 0)
            {
                Physics.IgnoreLayerCollision(8, 9, false);
                _player.transform.localScale = new Vector3(1.2f, 2.5f, 1.2f);
                disksCleared = true;
                bombImage.SetActive(false);
                broom.SetActive(true);
                broom.GetComponent<BroomScript>().FindAllSmallDisks();
            }
        }
        // Tüm küçük diskler temizlendi ise oyun bitiriliyor
        else if(smallDisksCleared)
        {
            PlayerMovement.cylinderIn = false;
            GameEnd(true);
        }
    }

    // Bu fonksiyon oyunu verilen bool değerine göre bitiriyor
    public void GameEnd(bool won)
    {
        _uiController.transform.GetComponent<InGameUIScript>().EndPanel(won);
    }
}
