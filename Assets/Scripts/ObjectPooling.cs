using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{

    public static ObjectPooling sharedInstance;



    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }




}
