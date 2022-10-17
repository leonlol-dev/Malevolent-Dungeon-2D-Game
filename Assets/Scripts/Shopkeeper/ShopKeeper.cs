using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public GameObject ShopUI;
    //public StoreItemContainer[] containers;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(ShopUI.transform.childCount);
        //for (int i = 0; i < ShopUI.transform.childCount; i++)
        //{
        //    containers[i] = ShopUI.transform.GetChild(i).GetComponent<StoreItemContainer>();
        //}

        ShopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered");
            ShopUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Exited");
            ShopUI.SetActive(false);
        }
    }
}
