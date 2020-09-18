using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu sınıfta kullanıcı girişleri kontrol edilip karakter girişlere göre hareket ettiriliyor
public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed = 200f;
    public static bool cylinderIn;

    private Transform _connector;
    private Transform[] _cylinders;
    private int _cylinderIndex = 0;
    private GameObject _cam;
    private GameObject[] _planes;
    private GameManager gm;


    void Start()
    {
        cylinderIn = true;
        _cylinders = new Transform[2];
        _connector = this.gameObject.transform.GetChild(0);
        _cylinders[0] = this.gameObject.transform.GetChild(1);
        _cylinders[1] = this.gameObject.transform.GetChild(2);
        _planes = GameObject.FindGameObjectsWithTag("Plane");
        _cam = GameObject.Find("Main Camera");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    

    void Update()
    {
        // Kullanıcının tıklama yapması kontrol ediliyor
        if ((Input.GetMouseButtonDown(0) && cylinderIn) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && cylinderIn))
        {
            // Önceki silindir indexi kontrol edilip diğerine geçiliyor
            if (_cylinderIndex == 0)
            {
                _cam.GetComponent<PlayerFollow>().whichCylinder = 2;
                _cylinderIndex = 1;
            }
            else
            {
                _cam.GetComponent<PlayerFollow>().whichCylinder = 1;
                _cylinderIndex = 0;
            }
            // Aktif silindirin tüm oynama düzlemlerinin dışarısında olup olmadığı kontrol ediliyor
            for (int i = 0; i < _planes.Length; i++)
            {
                if (_planes[i].transform.position.x - _planes[i].transform.localScale.x / 2 <= _cylinders[_cylinderIndex].position.x && _planes[i].transform.position.x + _planes[i].transform.localScale.x / 2 >= _cylinders[_cylinderIndex].position.x)
                {
                    if (_planes[i].transform.position.z - _planes[i].transform.localScale.z / 2 <= _cylinders[_cylinderIndex].position.z && _planes[i].transform.position.z + _planes[i].transform.localScale.z / 2 >= _cylinders[_cylinderIndex].position.z)
                    {
                        cylinderIn = true;
                        break;
                    }
                    else
                        cylinderIn = false;
                }
                else
                    cylinderIn = false;
            }
            // Silindir dışarıda ise oyun bitiriliyor
            if (!cylinderIn)
            {
                gm.GameEnd(false);
            }
        }
    }

    void FixedUpdate()
    {
        // Aktif silindirin etrafında karakter döndürülüyor
        if (cylinderIn)
        {
            this.transform.RotateAround(_cylinders[_cylinderIndex].position, new Vector3(0f, _cylinderIndex == 0f ? 1f : -1f, 0f), rotateSpeed * Time.deltaTime);
        }
    }
    
}
