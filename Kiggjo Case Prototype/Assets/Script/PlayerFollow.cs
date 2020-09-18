using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu sınıfta kameranın takibi yapılıyor
public class PlayerFollow : MonoBehaviour
{
    public Transform cylinder1;
    public Transform cylinder2;

    [HideInInspector]
    public int whichCylinder = 1;

    private float _transtionSpeed = 10f;
    

    public void FixedUpdate()
    {
        // Kullanıcı tıkladığında kamera aktif silindire göre hareket takibi yapıyor
        if (Input.GetMouseButton(0) || (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            if (whichCylinder == 1)
            {
                Vector3 newPos = new Vector3(cylinder1.position.x, transform.position.y, cylinder1.position.z - 7f);
                transform.position = Vector3.Lerp(transform.position, newPos, _transtionSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 newPos = new Vector3(cylinder2.position.x, transform.position.y, cylinder2.position.z - 7f);
                transform.position = Vector3.Lerp(transform.position, newPos, _transtionSpeed * Time.deltaTime);
            }
            
        }
    }
}
