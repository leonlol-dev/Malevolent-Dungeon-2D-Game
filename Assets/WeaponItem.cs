using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponItem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private TextMeshProUGUI textMeshProUGUI;
    private PlayerShooting playerShoot;

    public Weapon weapon;
    public GameObject text;

    private bool playerInProximity;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshProUGUI = text.GetComponent<TextMeshProUGUI>();

        //Set the text
        textMeshProUGUI.text = (weapon.weaponName + "\n" + "Press 'E' to pick up.");

        //Disable text Game Object 
        text.SetActive(false);

        //Set player in proximity to false.
        playerInProximity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInProximity)
        {
            player.GetComponent<PlayerAudioHandler>().pickUpSound(true);
            //player get weapon
            playerShoot.PickUpWeapon(weapon);
            Destroy(this.gameObject);
        }

        else if (Input.GetKeyDown(KeyCode.E) && playerInProximity)
        {
            //Play Reject clip
            player.GetComponent<PlayerAudioHandler>().pickUpSound(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Player is in proximity
            playerInProximity = true;

            //Retrieve the player special script upon collision. (better performance I think?)
            playerShoot = collision.gameObject.GetComponent<PlayerShooting>();

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
