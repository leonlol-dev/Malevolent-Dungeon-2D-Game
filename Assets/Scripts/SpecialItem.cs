using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpecialItem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private TextMeshProUGUI textMeshProUGUI;
    private PlayerSpecialAttack playerSpecial;

    public SpecialAttack specialAttack;
    public GameObject text;


    

    public bool playerInProximity;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshProUGUI = text.GetComponent<TextMeshProUGUI>();

        //Find player so it stops those annoying null references but they don't actually matter.
        player = GameObject.FindGameObjectWithTag("Player");

        //Set the text
        textMeshProUGUI.text = (specialAttack.title + "\n" + "Press 'E' to pick up.");

        //Disable text Game Object 
        text.SetActive(false);

        //Set player in proximity to false.
        playerInProximity = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E) && playerInProximity && playerSpecial.canSpecial)
        //{
        //    player.GetComponent<PlayerAudioHandler>().pickUpSound(true);
        //    playerSpecial.PickUpSpecial(specialAttack);
        //    Destroy(this.gameObject);
        //}

        //else if (Input.GetKeyDown(KeyCode.E) && !playerSpecial.canSpecial && playerInProximity)
        //{
        //    //Play Reject clip
        //    player.GetComponent<PlayerAudioHandler>().pickUpSound(false);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Player is in proximity
            playerInProximity = true;

            //Retrieve the player special script upon collision. (better performance I think?)
            playerSpecial = collision.gameObject.GetComponent<PlayerSpecialAttack>();

            player = collision.gameObject;

            //Set the text true.
            text.SetActive(true);

      
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInProximity = false;
            text.SetActive(false);
        }
    }
}
