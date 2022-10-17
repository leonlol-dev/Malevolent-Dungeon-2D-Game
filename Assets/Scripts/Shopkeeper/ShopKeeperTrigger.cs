using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopKeeperTrigger : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject text;

    private bool playerInProximity;
    // Start is called before the first frame update
    void Start()
    {
        ShopUI = GameObject.FindWithTag("Shop");
        ShopUI.SetActive(false);
        text.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered");
            ShopUI.SetActive(true);
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Exited");
            ShopUI.SetActive(false);
            text.SetActive(false);
        }
    }
}
