using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Bu sınıf oyun içi UI elementlerini kontrol ediyor
public class InGameUIScript : MonoBehaviour
{
    public Text gameOverText;
    public GameObject inGamePanel;
    public GameObject gameOverPanel;
    
    // Bu fonksiyon verilen bool değerine göre oyun bitiş panelinde kazandın veya kaybettin yazdırıyor
    public void EndPanel(bool won)
    {
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        if (won)
            gameOverText.text = "\n\nYOU WON!";
        else
            gameOverText.text = "\n\nGAME OVER!";
    }
    // Bu fonksiyon oyun sahnesini tekrar başlatıyor
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Bu fonksiyon menü sahnesine geçiş yapıyor
    public void GoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
