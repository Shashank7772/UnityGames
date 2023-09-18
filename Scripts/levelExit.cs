using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] Animator levelTransitionAnimation;
    AudioManager audioManager;

    void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            StartCoroutine(loadNextScene());
        }
    }

    IEnumerator loadNextScene()
    {
        audioManager.playSFX(audioManager.levelComplete);
        levelTransitionAnimation.SetTrigger("End");
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex +1 ;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
            audioManager.musicSource.Stop();
        }
        FindObjectOfType<ScenePersist>().resetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
        levelTransitionAnimation.SetTrigger("Start");
    }
}
