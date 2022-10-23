using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopKeeperTrigger : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject text;
    public TextTypingAnimation anim;

    private GameObject player;
    private bool playerInProximity;
    private bool shopOpen;
    private bool playerText;
    private bool textActive = true;
    // Start is called before the first frame update
    void Start()
    {
        ShopUI = GameObject.FindWithTag("Shop");
        ShopUI.SetActive(false);
        text.SetActive(false);
        shopOpen = false;
    }

    private void Update()
    {
        //I should probably put this into a child of the player (preferably the interact text), but I think this is okay.
        if(Input.GetKeyDown(KeyCode.E) && playerInProximity )
        {
            OpenUI();
        }

        //if (Input.GetKeyDown(KeyCode.E) && playerInProximity)
        //{
        //    CloseUI();
        //}


    }

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision == player)
        {
            if (textActive)
            {
                //If statement so the text doesn't constantly show up when I'm trying to deactivate it.
                textActive = false;

                // Player's get child (7) is the interact text.
                player.transform.GetChild(7).gameObject.SetActive(true);
            }

            playerInProximity = true;
            text.SetActive(true);
            anim.PlayAnimation();


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            // Player's get child (7) is the interact text.
            player.transform.GetChild(7).gameObject.SetActive(false);

            playerInProximity = false;
            text.SetActive(false);
            textActive = true;

            CloseUI();
            anim.Clear();

        }
    }

    private void CloseUI()
    {
        //shopOpen = false;
        ShopUI.SetActive(false);
        player.GetComponent<PlayerShooting>().canFire = true;

    }

    private void OpenUI()
    {
        //shopOpen = true;
        ShopUI.SetActive(true);
        player.GetComponent<PlayerShooting>().canFire = false;
        player.transform.GetChild(7).gameObject.SetActive(false);
    }
}
