using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : ScriptableObject
{
    public enum consumeType
    {
        Health,

    }

    public consumeType type;
}
