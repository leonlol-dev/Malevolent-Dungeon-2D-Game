using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatCalculator : MonoBehaviour
{
    PlayerMovement movementScript;
    PlayerShooting shootingScript;

    private void Start()
    {
        movementScript = GetComponent<PlayerMovement>();
        shootingScript = GetComponent<PlayerShooting>();
    }
    public void CalculateTotalStats()
    {
        movementScript.CalculateTotal();
        shootingScript.CalculateTotal();
    }
}
