using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialAttack : ScriptableObject
{
  
    public abstract void Special(GameObject player);
    public abstract void Return(GameObject player);

}
