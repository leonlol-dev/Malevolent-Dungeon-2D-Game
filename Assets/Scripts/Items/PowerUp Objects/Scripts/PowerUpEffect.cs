using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    public string title;
    public string description;
    public abstract void Apply(GameObject target);
    public abstract int getCost { get; }

}
