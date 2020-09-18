using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Bu sınıfta menü sahnesindeki UI elementleri kontrol ediliyor
public class MenuScript : MonoBehaviour
{
    public Text soundButtonText;

    private bool _soundOn = true;

    // Bu fonksiyon play tuşuna basılınca oyun sahnesini açıyor
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    // Bu fonksiyon ses açma kapama tuşuna basılınca sesi açıp kapıyor
    public void SoundOnOff()
    {
        FindObjectOfType<AudioManager>().ChangeVolume("Theme", _soundOn);
        if (_soundOn)
        {
            soundButtonText.text = "SOUND OFF";
            _soundOn = false;
        }
        else
        {
            soundButtonText.text = "SOUND ON";
            _soundOn = true;
        }
    }

    // Bu fonksiyon çıkış butonuna basılınca uygulamadan çıkış yapıyor
    public void Quit()
    {
        Application.Quit();
    }
}
