using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameOver;

    public int score;

    public bool gamePaused;

    private HUD hud;

    public GameObject bossPrefab;

    public GameObject spawner;

    private float timeToBoss;

    private bool bossFight = true;

    public bool bossDead;

    private void Awake()
    {
        //INICIALIZAR EL HUD
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        FindObjectOfType<AudioManager>().Play("GameplayMusic");

        score = 0;
        hud.UpdateScoreText(score);
    }

    private void Update()
    {
        timeToBoss += Time.deltaTime;
        if(timeToBoss >= 60 && bossFight)
        {
            FindObjectOfType<AudioManager>().Stop("GameplayMusic");
            FindObjectOfType<AudioManager>().Play("BossMusic");
            BandasArriba();
            Instantiate(bossPrefab);
            spawner.SetActive(false);
            bossFight = false;
        }
        if (bossDead)
        {
            FindObjectOfType<AudioManager>().Play("BossDie");
            timeToBoss = 0;
            spawner.SetActive(true);
            bossFight = true;
            FindObjectOfType<AudioManager>().Play("GameplayMusic");
            FindObjectOfType<AudioManager>().Stop("BossMusic");
            bossDead = false;
        }
    }

    public void PlayBttnSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonsSound");
    }

    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1;
        hud.ClosePausePanel();
    }

    public void Pause()
    {
        PlayBttnSound();
        gamePaused = true;
        Time.timeScale = 0;
        hud.OpenPausePanel();
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        hud.UpdateScoreText(score);
    }

    private void SaveGame()
    {
        int highScore = 0;

        //COGER HIGH SCORE ALMACENADA
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        //ESTABLECEMOS PUNTUACIONES
        if (score > highScore)
        {
            highScore = score;
        }

        //ALMACENAR PUNTUACIONES
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void PlayerLife(int pLife)
    {
        hud.UpdatePlayerLifeText(pLife);
    }

    public void GameOver()
    {
        FindObjectOfType<AudioManager>().Stop("BossMusic");

        FindObjectOfType<AudioManager>().Play("GameplayMusic");

        gameOver = true;
        SaveGame();

        LoadScene("GameOver");
    }

    public void BandasArriba()
    {
        hud.animSup.SetTrigger("entra");
        hud.animInf.SetTrigger("entra");
    }

    public void BandasAbajo()
    {
        hud.animSup.SetTrigger("sal");
        hud.animInf.SetTrigger("sal");
    }
}
