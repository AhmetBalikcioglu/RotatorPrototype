using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Bu sınıfta karakter ile disklerin çarpışmaları kontrol ediliyor
public class PlayerCollision : MonoBehaviour
{
    public GameObject smallDiskPrefab;
    public Material[] allMats;
    private float _blowForce = 200f;
    

    void OnCollisionEnter(Collision collisionInfo)
    {
        // Diskler ile çarpışma kontrol ediliyor
        if (collisionInfo.collider.tag == "Disk" && collisionInfo.gameObject.active)
        {
            float rand = Random.Range(2, 4);
            collisionInfo.gameObject.SetActive(false);
            // Diskin olduğu konumdan rastgele 2 ile 4 arasında küçük disk spawnlanıyor. Bu küçük disklere rastgele renk ve force(patlama efekti) atanıyor
            for (int i = 0; i < rand; i++)
            {
                float rand1 = Random.Range(-_blowForce, _blowForce);
                float rand2 = Random.Range(-_blowForce, _blowForce);
                GameObject tempDisk = Instantiate(smallDiskPrefab, collisionInfo.gameObject.transform.position, Quaternion.identity);
                int rand3 = Random.Range(0, allMats.Length);
                tempDisk.GetComponent<Renderer>().material = allMats[rand3];
                tempDisk.GetComponent<Rigidbody>().AddForce(rand1 * Time.deltaTime, _blowForce * Time.deltaTime, rand2 * Time.deltaTime, ForceMode.VelocityChange);
            }
            Destroy(collisionInfo.gameObject);
            // Her büyük diske çarpıldığında bomba sayımı bir arttırılıyor
            Bomb.bombValue += 1;
        }
    }
}
