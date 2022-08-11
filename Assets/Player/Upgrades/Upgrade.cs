using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Upgrade : ScriptableObject
{
    public GameObject prefab;


    [TextArea(15, 20)]
    public string description;
    
}
