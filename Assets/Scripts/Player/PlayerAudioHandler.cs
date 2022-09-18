using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip accept;
    public AudioClip reject;
    // Start is called before the first frame update
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
}
