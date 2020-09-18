using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bu sınıf bomba elementinin kontrollerini yapıyor
public class Bomb : MonoBehaviour
{
    public static int bombValue;
    public Image bombImage;

    private Transform _connector;
    private Vector3 _connectorColliderSize;
    private Vector3 _connectorColliderCenter;


    void Start()
    {
        bombValue = 0;
        _connector = this.gameObject.transform.GetChild(0);
        _connectorColliderSize = _connector.GetComponent<BoxCollider>().size;
        _connectorColliderCenter = _connector.GetComponent<BoxCollider>().center;
    }
    
    void Update()
    {
        // Büyük disklerinin temizlenme kontrolünü yapılıyor
        if (!GameManager.disksCleared)
        {
            // Bomba sayımı 100e ulaşınca karakter colliderini yarım saniyeliğine arttırıp azaltıyor. Bu sayede karakter etrafındaki diskler patlıyor
            if (bombValue >= 100)
            {
                //Debug.Log(bombValue);
                FindObjectOfType<AudioManager>().Play("BombSound");
                BombActive();
                Invoke("BombDeactive", 0.5f);
            }
            bombImage.rectTransform.localScale = new Vector3((float)bombValue / 100f, (float)bombValue / 100f, 1f);
            bombImage.rectTransform.anchoredPosition = new Vector3(((float)bombValue / 3.3f) - 30f, ((float)bombValue / 3.3f) - 30f, 0f);
        }
    }
    // Bu fonksiyon karakter colliderını büyütüyor
    void BombActive()
    {
        _connector.GetComponent<BoxCollider>().size = new Vector3(5.8f, 10.9f, 1.95f);
        _connector.GetComponent<BoxCollider>().center = new Vector3(-0.08f, 3.62f, -0.01f);
        bombValue = 0;
    }
    // Bu fonksiyon karakter colliderını eski haline çeviriyor
    void BombDeactive()
    {
        _connector.GetComponent<BoxCollider>().size = _connectorColliderSize;
        _connector.GetComponent<BoxCollider>().center = _connectorColliderCenter;
        
    }

}
