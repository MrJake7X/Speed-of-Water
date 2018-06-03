using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("TitleMusic");
    }

    public void LoadNextScene()
    {
        FindObjectOfType<AudioManager>().Stop("TitleMusic");
        FindObjectOfType<AudioManager>().Play("GameplayMusic");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
