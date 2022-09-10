using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public SpecialAttack specialAtk;
    private GameObject player;

    public float cooldown;
    private bool canSpecial;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpecial)
        {
           
        }
    }

}
