using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartGame(int numScene)
    {
        PlaySound();

        SceneManager.LoadScene(numScene);
    }

    public void QuitGame()
    {
        PlaySound();

        Application.Quit();
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonsSound");
    }

    // AUDIO OPTIONS
    public AudioMixer musicMixer;
    
    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("volume", volume);
    }

    public AudioMixer soundsMixer;

    public void SetSoundsVolume(float volume)
    {
        soundsMixer.SetFloat("volume", volume);
    }
}
