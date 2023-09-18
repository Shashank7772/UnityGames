using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource mainmenuMusic;
    [SerializeField] AudioClip audioClip;
    void Start() 
    {
        mainmenuMusic.clip = audioClip;
        mainmenuMusic.Play();
    }
    public void playGame()
    {
        SceneManager.LoadScene(1);
        mainmenuMusic.Stop();
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
