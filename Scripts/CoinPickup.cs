using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int pointsPerCoin = 100;
    bool wasCollected;
    AudioManager audioManager;

    void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)   
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().addToScore(pointsPerCoin);
            audioManager.playSFX(audioManager.coinPickup);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
    }
}
