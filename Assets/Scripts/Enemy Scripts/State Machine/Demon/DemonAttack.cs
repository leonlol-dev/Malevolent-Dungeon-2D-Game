using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : DemonBaseState
{
    public override void Start(StateMachine_Demon demon)
    {

    }

    public override void EnterState(StateMachine_Demon demon)
    {
        demon.attackScript.canFire = true;
        //demon.path.canMove = false;
    }

    public override void UpdateState(StateMachine_Demon demon)
    {

    }

    public override void FixedUpdateState(StateMachine_Demon demon)
    {

    }

    public override void OnTriggerEnter(StateMachine_Demon demon, Collider2D collider)
    {
        //NONE
    }

    public override void LeaveState(StateMachine_Demon demon)
    {
        demon.attackScript.canFire = false;
        //demon.path.canMove = true;
    }
}
