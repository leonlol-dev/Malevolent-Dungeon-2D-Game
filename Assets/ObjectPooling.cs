using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{

    public static ObjectPooling sharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public bool pooled = false;

    // Start is called before the first frame update
    void Start()
    {
    

    }

    public void Update()
    {
        if (!pooled)
        {
            pooled = true;
            sharedInstance = GetComponent<ObjectPooling>();

            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(gameObject);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void SetPooledObject(GameObject _objectToPool)
    {
        objectToPool = _objectToPool;
    }
    

}
