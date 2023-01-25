using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    //This script is used because its better to have the audio behaviour on the player rather than the item to stop sounds from stopping mid way through
    //due to the item destroying it self.

    [Header("Sounds")]
    public AudioClip accept;
    public AudioClip reject;
    public AudioClip[] coinCollect;
    public AudioClip[] potionUse;
    public AudioClip[] powerUp;

    [Header("Volume")]
    public float defaultVolume = 0.5f;
    public float decreasedVolume = 0.1f;

    //Private
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    public void playSound(AudioClip _clip)
    {
        audioSource.PlayOneShot(_clip);
    }
    public void pickUpSound(bool _accept)
    {
        if (_accept)
        {
            audioSource.PlayOneShot(accept);
        }
        else 
        {
            audioSource.PlayOneShot(reject);
        }

    }

    public void coinCollectSound()
    {
        audioSource.PlayOneShot(coinCollect[Random.Range(0, coinCollect.Length)]);
    }

    public void potionConsumeSound()
    {
        audioSource.PlayOneShot(potionUse[Random.Range(0, potionUse.Length)]);
    }

    public void powerUpSound()
    {
        // If audio stacks reduce the overall volume to reduce hurting the player's ears 
        // if they manage to collect a bunch of coins at once.

        if (audioSource.isPlaying)
        {
            audioSource.PlayOneShot(powerUp[Random.Range(0, powerUp.Length)], decreasedVolume);
        }
        else
        {
            audioSource.PlayOneShot(powerUp[Random.Range(0, powerUp.Length)], defaultVolume);
        }
        
        
    }
}
