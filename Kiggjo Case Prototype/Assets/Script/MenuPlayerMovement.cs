using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu sınıf menüde karakterin hareketlerini kontrol ediyor
public class MenuPlayerMovement : MonoBehaviour
{
    private Transform _cylinder;
    private float _rotateSpeed = 150f;

    void Start()
    {
        _cylinder = this.gameObject.transform.GetChild(1);
    }
    
    void Update()
    {
        this.transform.RotateAround(_cylinder.position, new Vector3(0f, 1f, 0f), _rotateSpeed * Time.deltaTime);
    }
}
