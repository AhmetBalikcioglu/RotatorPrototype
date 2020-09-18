using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu sınıf küçük diskleri çarpışmaya göre silip, skor arttıyor
public class Destroyer : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        // Her küçük disk skor değerine 10 ekliyor
        Score.scoreValue += 10;
        // Temizlik safhasında temizleme 1 değer arttırılıyor
        BroomScript.smallDiskCleared += 1;
        Destroy(collisionInfo.gameObject);
    }
}