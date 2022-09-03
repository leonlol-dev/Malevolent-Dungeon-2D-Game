using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public SpecialAttack specialAtk;
    public Shooting shootingScript;

    public float cooldown;
    private bool canSpecial;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpecial)
        {

        }
    }

}
