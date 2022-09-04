using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;
    public AudioClip[] powerUpSounds;

    private SpriteRenderer rend;
    private AudioSource powerUpAudio;
    private bool activated;

    private void Start()
    {
        //Get Components
        rend = GetComponent<SpriteRenderer>();
        powerUpAudio = GetComponent<AudioSource>();

        //Choose a random sound.
        //powerUpAudio.clip = powerUpSounds[Random.Range(0, powerUpSounds.Length)];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if(collision.gameObject.tag == "Player" && !activated)
        {
            //Set bool
            activated = true;

            //Play the clip.
            powerUpAudio.PlayOneShot(powerUpSounds[Random.Range(0, powerUpSounds.Length)]);

            rend.enabled = false;
            Destroy(gameObject, 0.75f);
            powerUpEffect.Apply(collision.gameObject);
        }
      
    }
}
