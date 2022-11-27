using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocatorForEnemies : MonoBehaviour
{
    public StateMachine_Demon stateMachine;

    private void Start()
    {
        stateMachine = this.transform.GetComponentInParent<StateMachine_Demon>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            stateMachine.enemyNearby = true;
        }

   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            stateMachine.enemyNearby = false;
        }
    }




}
