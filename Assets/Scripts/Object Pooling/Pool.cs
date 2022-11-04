using UnityEngine;
using System.Collections.Generic;

/* 
 * ALL ITEM IDS
 * 1 - STARTING SWORD
 * 2 - HOMING SWORD
 * 3 - AXE
 * 4 - DAGGERS
 * 5 - FLYING SKULL
 * 6 - DEATH SICKLE
 * 7 - EXCALIBUR
 *
*/


[System.Serializable]
public class PooledObject
{
    public GameObject Object;
    public int Amount;
}

public class Pool : MonoBehaviour
{
    public static Pool Instance;
    public PooledObject[] Objects;
    private List<GameObject>[] pool;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameObject temp;
        pool = new List<GameObject>[Objects.Length];

        for (int count = 0; count < Objects.Length; count++)
        {
            pool[count] = new List<GameObject>();
            for (int num = 0; num < Objects[count].Amount; num++)
            {
                temp = (GameObject)Instantiate(Objects[count].Object, new Vector3(0.0f, 1000.0f, 0.0f), Quaternion.identity);
                temp.SetActive(false);
                temp.transform.parent = transform;
                pool[count].Add(temp);
            }
        }
    }
    public GameObject Activate(int id, Vector3 position, Quaternion rotation)
    {
        for (int count = 0; count < pool[id].Count; count++)
        {
            if (!pool[id][count].activeSelf)
            {
                GameObject currObj = pool[id][count];
                Transform currTrans = currObj.transform;

                currObj.SetActive(true);
                currTrans.position = position;
                currTrans.rotation = rotation;
                return currObj;
            }
        }
        GameObject newObj = Instantiate(Objects[id].Object) as GameObject;
        Transform newTrans = newObj.transform;
        newTrans.position = position;
        newTrans.rotation = rotation;
        newTrans.parent = transform;
        pool[id].Add(newObj);
        return newObj;
    }

    public void Deactivate(GameObject obj)
    {
        obj.SetActive(false);
    }
}

