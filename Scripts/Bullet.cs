using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float bulletSpeed = 1f;
    PlayerMovement player;
    float axisSpeed;
    [SerializeField] ParticleSystem blastEffect;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        myRigidBody = GetComponent<Rigidbody2D>();
        axisSpeed = player.transform.localScale.x * bulletSpeed;
    }
    void Update()
    {
        myRigidBody.velocity = new Vector2 (axisSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemies")
        {
            Destroy(other.gameObject);
            blastEffect.Play();
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
    
