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

    //Private
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
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
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(coinCollect[Random.Range(0, coinCollect.Length)]);
        }
        
    }
}
