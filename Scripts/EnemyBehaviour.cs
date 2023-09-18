using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    BoxCollider2D boxCollider2D;
    Rigidbody2D rigidBody2D;
    bool isAlive = true;
    AudioManager audioManager;

    void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        move();
    }
    void move()
    {
        if(!isAlive)
        {
            return;
        }
        else
        {
        rigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        moveSpeed = -moveSpeed;
        flipTheEnemy();
    }
    void flipTheEnemy()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidBody2D.velocity.x)), 1f);
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            flipTheEnemy();
        }
        else if(other is CapsuleCollider2D capsuleCollider)
        {
            isAlive = false;
            audioManager.playSFX(audioManager.enemyDeath);
            Vector2 enemyVelocityafterDeath = new Vector2(0f,0f);
            rigidBody2D.velocity = enemyVelocityafterDeath;
        }
    }
}
