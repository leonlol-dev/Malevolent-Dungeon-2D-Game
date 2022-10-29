using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreItemContainer : MonoBehaviour
{
    public enum itemType
    {
        Weapon,
        Special,
        PowerUp,
        Health,
    }
    [Header("Item Type")]
    public itemType type;
    
    [Header("Items you want to sell.")]
    public GameObject[] items;

    private GameObject item;

    //UI
    [Header("UI")]
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemGold;
    private Button button;

    

    //Private
    private WeaponItem weaponPrefab;
    private SpecialItem specialAttackPrefab;
    private PowerUp powerUpPrefab;
    private HealthPotion potionPrefab;
    private GameObject player;
    private GameObject shopKeepersTrigger;
    private int itemCost;
    private bool bought;

    // Start is called before the first frame update
    void Start()
    {
        //Set bought to false, if player wants to buy this item, this needs to be set to false.
        bought = false;

        //Find components
        player = GameObject.FindWithTag("Player");
        button = GetComponent<Button>();

        //Random item selection
        item = items[Random.Range(0, items.Length)];

        itemTypeSelector(type);

        
    }

    private void Awake()
    {
        //Set new shop items everytime a new instance of the shop keeper items
        RandomiseShop();
    }

    //Select which type the item is and set the display variables (logo, text, sprite, etc).
    public void itemTypeSelector(itemType _type)
    {
        switch (_type)
        {
            default:
                Debug.Log("Failed to initialise item.");
                break;

            case itemType.Weapon:
                weaponPrefab = item.GetComponent<WeaponItem>();
                itemIcon.sprite = weaponPrefab.GetComponent<SpriteRenderer>().sprite;
                itemName.text = weaponPrefab.weapon.name;
                itemDescription.text = weaponPrefab.weapon.weaponDescription;
                itemGold.text = weaponPrefab.weapon.goldCost.ToString();
                itemCost = weaponPrefab.weapon.goldCost;
                ErrorCheck(_type, weaponPrefab);
                break;

            case itemType.Special:
                specialAttackPrefab = item.GetComponent<SpecialItem>();
                itemIcon.sprite = specialAttackPrefab.GetComponent<SpriteRenderer>().sprite;
                itemName.text = specialAttackPrefab.specialAttack.title;
                itemDescription.text = specialAttackPrefab.specialAttack.description;
                itemGold.text = specialAttackPrefab.specialAttack.goldCost.ToString();
                itemCost = specialAttackPrefab.specialAttack.goldCost;
                ErrorCheck(_type, specialAttackPrefab);
                break;

            case itemType.PowerUp:
                powerUpPrefab = item.GetComponent<PowerUp>();
                itemIcon.sprite = powerUpPrefab.GetComponent<SpriteRenderer>().sprite;
                itemName.text = powerUpPrefab.powerUpEffect.title;
                itemDescription.text = powerUpPrefab.powerUpEffect.description;
                itemGold.text = powerUpPrefab.powerUpEffect.getCost.ToString();
                itemCost = powerUpPrefab.powerUpEffect.getCost;
                ErrorCheck(_type, powerUpPrefab);
                break;

            case itemType.Health:
                potionPrefab = item.GetComponent<HealthPotion>();
                itemIcon.sprite = potionPrefab.GetComponent<SpriteRenderer>().sprite;
                itemName.text = potionPrefab.gameObject.name;
                itemDescription.text = "Heal you by " + potionPrefab.health.ToString() + "HP";
                itemGold.text = potionPrefab.goldCost.ToString();
                itemCost = potionPrefab.goldCost;
                ErrorCheck(_type, potionPrefab);
                break;
        }
    }

    public void PlayerBuy(itemType _type)
    {
        //Get player's currency script to access player's money.
        PlayerCurrency pGold = player.GetComponent<PlayerCurrency>();

        //If player's gold is more than the item cost AND if the item hasn't been bought. 
        if (pGold.gold >= itemCost && bought == false)
        {
            //Take away the player's gold
            pGold.gold -= itemCost;

            switch (_type)
            {
                default:
                    Debug.Log("Failed to buy item.");
                    break;

                case itemType.Weapon:
                    PlayerShooting pShootScript = player.GetComponent<PlayerShooting>();
                    pShootScript.PickUpWeapon(weaponPrefab.weapon);
                    bought = true;
                    break;

                case itemType.Special:
                    PlayerSpecialAttack pSpecialScript = player.GetComponent<PlayerSpecialAttack>();
                    pSpecialScript.PickUpSpecial(specialAttackPrefab.specialAttack);
                    bought = true;
                    break;

                case itemType.PowerUp:
                    powerUpPrefab.BuyPowerUp(player);
                    bought = true;
                    break;

                case itemType.Health:
                    if (player.GetComponent<PlayerHealth>().currentHealth != player.GetComponent<PlayerHealth>().maxHealth)
                    {
                        potionPrefab.BuyHeal(player);
                        bought = true;
                    }
                    break;
            }

            if(bought == true)
            {
                //Set colour of button to dark grey to signify it's been bought
                button.interactable = false;
            }

        }

        else if(bought == true)
        {
            Debug.Log("You cannot buy this again.");

        }

        else
        {
            Debug.Log("You cannot afford this.");
        }


    }

    public void OnButtonPress()
    {
        PlayerBuy(type);
    }


    public void Reject()
    {
        PlayerAudioHandler playerAudio = player.GetComponent<PlayerAudioHandler>();

    }

    //When the player finds a new shopkeeper change the items.
    public void RandomiseShop()
    {
        item = items[Random.Range(0, items.Length)];
    }















    //Overloaded error check message function.
    public void ErrorCheck(itemType _type, WeaponItem _weapon)
    {
       if (_weapon == null)
        {
            Debug.Log("Failed to initialise weapon, check if you have the right item type.");
        }
    }

    public void ErrorCheck(itemType _type, SpecialItem _sAttack)
    {
        if(_sAttack == null)
        {
            Debug.Log("Failed to initialise special, check if you have the right item type.");
        }
    }

    public void ErrorCheck(itemType _type, PowerUp _powerUp)
    {
        if(_powerUp == null)
        {
            Debug.Log("Failed to initialise power up, check if you have the right item type.");
        }
    }

    public void ErrorCheck(itemType _type, HealthPotion _potion)
    {
        if(_potion == null)
        {
            Debug.Log("Failed to initalise health potion, check if you have the right item type.");
        }
    }

}
