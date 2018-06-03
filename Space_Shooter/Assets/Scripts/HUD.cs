using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public GameObject pausePanel;

    public Text scoreText;

    public Text lifeText;

    public Animator animSup;

    public Animator animInf;

    // Use this for initialization
    void Start()
    {
        ClosePausePanel();
    }

    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString("000000");
    }

    public void UpdatePlayerLifeText(int pLife)
    {
        lifeText.text ="x" + pLife.ToString("0");
    }
}
