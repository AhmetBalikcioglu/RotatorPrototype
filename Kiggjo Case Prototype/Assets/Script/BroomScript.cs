using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bu sınıf temizlik safhasını kontrol ediyor
public class BroomScript : MonoBehaviour
{
    public Slider slider;
    public Image broomImage;
    public static int smallDiskCleared;

    private GameObject[] _smallDisksInScene;
    private int _smallDiskTotal;
    
    // Bu fonksiyon sahnedeki küçük diskleri bulup, sayısına göre süpürgeyi barda ilerletiyor
    public void FindAllSmallDisks()
    {
        _smallDisksInScene = GameObject.FindGameObjectsWithTag("SmallDisk");
        _smallDiskTotal = _smallDisksInScene.Length;
        smallDiskCleared = 0;
        slider.maxValue = _smallDiskTotal;
        slider.value = smallDiskCleared;

        broomImage.rectTransform.anchoredPosition = new Vector3(0f, 55f, 0f);
    }
    

    void Update()
    {
        broomImage.rectTransform.anchoredPosition = new Vector3((240f * (float)smallDiskCleared) / (float)_smallDiskTotal, 55f, 0f);
        slider.value = smallDiskCleared;
        if (slider.value >= slider.maxValue)
        {
            GameManager.smallDisksCleared = true;
        }
    }
}
