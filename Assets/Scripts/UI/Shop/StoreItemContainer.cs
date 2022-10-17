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

    //Private
    private WeaponItem weaponPrefab;
    private SpecialItem specialAttackPrefab;
    private PowerUp powerUpPrefab;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        item = items[Random.Range(0, items.Length)];

        itemTypeSelector(type);

        
    }

    private void Awake()
    {
        //Set new shop items everytime a new instance of the shop keeper items
        item = items[Random.Range(0, items.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                ErrorCheck(_type, weaponPrefab);
                break;

            case itemType.Special:
                specialAttackPrefab = item.GetComponent<SpecialItem>();
                itemIcon.sprite = specialAttackPrefab.GetComponent<SpriteRenderer>().sprite;
                itemName.text = specialAttackPrefab.specialAttack.title;
                itemDescription.text = specialAttackPrefab.specialAttack.description;
                itemGold.text = specialAttackPrefab.specialAttack.goldCost.ToString();
                ErrorCheck(_type, specialAttackPrefab);
                break;

            case itemType.PowerUp:
                //powerUp = item.GetComponent <PowerUp>();
                //ErrorCheck(_type, powerUp);
                break;

            case itemType.Health:
                break;
        }
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

}
