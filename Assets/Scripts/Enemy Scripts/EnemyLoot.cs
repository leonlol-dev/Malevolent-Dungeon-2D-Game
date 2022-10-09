using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    public GameObject commonLoot;
    public GameObject uncommonLoot;
    public GameObject rareLoot;
    public GameObject epicRareLoot;
    public GameObject legendaryLoot;
    public GameObject impossibleLoot;

    public int goldSpam = 25;
    [SerializeField]
    private int chance;

    private void Awake()
    {
        chance = Random.Range(0, 100);
    }

    public void DropLoot()
    {
     
        switch(chance)
        {
            case int value when chance <= 50:
                //If chance lands before 50 (common drop 50%)
                InstantiateLoot(commonLoot);
                InstantiateLoot(commonLoot);
                InstantiateLoot(commonLoot);
                InstantiateLoot(commonLoot);
                Debug.Log("common drop");
                break;
            case int value when chance > 50 && value <= 75:
                //If chance lands between 25 and 50 (uncommon drop 25%)
                InstantiateLoot(commonLoot);
                InstantiateLoot(commonLoot);
                InstantiateLoot(commonLoot);
                Debug.Log("uncommon drop");
                break;
            case int value when chance > 75 && value <= 90:
                //If chance lands between 75 and 90 (rare drop 15%)
                InstantiateLoot(commonLoot);
                InstantiateLoot(rareLoot);
                Debug.Log("rare drop");
                break;
            case int value when chance > 90 && value <= 95:
                //If chance lands between 90 and 95 (epic rare drop 5%)
                InstantiateLoot(commonLoot);
                InstantiateLoot(epicRareLoot);
                Debug.Log("epic rare drop");
                break;
            case int value when chance > 95 && value <= 99:
                //If chance lands between 95 and 99 (legendary drop 4%)
                InstantiateLoot(legendaryLoot);
                Debug.Log("legendary drop");
                break;
            case 100:
                //If chance lands on 100 (impossible 1%)
                for(int i = 0; i < goldSpam; i++)
                {
                    InstantiateLoot(commonLoot);
                }
                Debug.Log("impossible drop");
                break;
            
        }
        
    }

    void InstantiateLoot(GameObject _loot)
    {
        //Instantiate loot on the enemy's position with no rotation.
        Instantiate(_loot, transform.position, Quaternion.identity);

        //If the loot is a coin play the animation.
        if (_loot.GetComponent<Coins>() != null)
        {
            Debug.Log("coin animation start");
            _loot.GetComponent<Coins>().canAnimate = true;


        }
    }
}
