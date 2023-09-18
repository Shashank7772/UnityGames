using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("**************Audio Source***************")]
    public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("***************Audio Clips****************")]
    public AudioClip background;
    public AudioClip playerDeath;
    public AudioClip enemyDeath;
    public AudioClip bullet;
    public AudioClip levelComplete;
    public AudioClip mushroomJump;
    public AudioClip coinPickup;


    void Start() 
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
