using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu sınıf diskler oyun başlangıcında spawnlanıyor
public class Spawner : MonoBehaviour
{
    public GameObject diskPrefab;
    public Material[] allMats;
    private Material _diskMat;

    // Tüm spawnlanma lokasyonlarında 1 ile 10 arasında rastgele renkler ile diskler spawnlanıyor
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                // Right side disk spawn
                int rand = Random.Range(1, 10);
                for (int k = 0; k < rand; k++)
                {
                    GameObject tempDisk = Instantiate(diskPrefab, new Vector3(4f + (float)i, 0f + (float)k / 3, 3f + (float)j), Quaternion.identity);
                    int rand1 = Random.Range(0, allMats.Length);
                    tempDisk.GetComponent<Renderer>().material = allMats[rand1];
                }
                // Left side disk spawn
                rand = Random.Range(1, 10);
                for (int k = 0; k < rand; k++)
                {
                    GameObject tempDisk = Instantiate(diskPrefab, new Vector3(-3f - (float)i, 0f + (float)k / 3, 3f + (float)j), Quaternion.identity);
                    int rand1 = Random.Range(0, allMats.Length);
                    tempDisk.GetComponent<Renderer>().material = allMats[rand1];
                }
            }
        }
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                // Close side disk spawn
                int rand = Random.Range(1, 10);
                for (int k = 0; k < rand; k++)
                {
                    GameObject tempDisk = Instantiate(diskPrefab, new Vector3(-2f + (float)i, 0f + (float)k / 3, -1.5f + (float)j), Quaternion.identity);
                    int rand1 = Random.Range(0, allMats.Length);
                    tempDisk.GetComponent<Renderer>().material = allMats[rand1];
                }
                // Far side disk spawn
                rand = Random.Range(1, 10);
                for (int k = 0; k < rand; k++)
                {
                    GameObject tempDisk = Instantiate(diskPrefab, new Vector3(-2f + (float)i, 0f + (float)k / 3, 11f + (float)j), Quaternion.identity);
                    int rand1 = Random.Range(0, allMats.Length);
                    tempDisk.GetComponent<Renderer>().material = allMats[rand1];
                }
            }
        }
    }
    
}
