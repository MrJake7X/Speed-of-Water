using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHUD : MonoBehaviour {

    public Text scoreText;

    public Text highScoreText;

        // Use this for initialization
    void Start ()
    {
        scoreText.text = "SCORE " + PlayerPrefs.GetInt("Score").ToString("0000");
        highScoreText.text = "HI " + PlayerPrefs.GetInt("HighScore").ToString("0000");
    }
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void PlayBttnSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonsSound");
    }
}
