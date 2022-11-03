using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonChase : DemonBaseState
{
    //Just sets the destination setter to player.
    public override void Start(StateMachine_Demon demon)
    {
        
    }

    public override void EnterState(StateMachine_Demon demon)
    {
        demon.dSetter.target = demon.player.transform;
    }

    public override void UpdateState(StateMachine_Demon demon)
    {

    }

    public override void FixedUpdateState(StateMachine_Demon demon)
    {
        demon.dSetter.target = demon.player.transform;
    }

    public override void OnTriggerEnter(StateMachine_Demon demon, Collider2D collider)
    {
        //NONE
    }

    public override void LeaveState(StateMachine_Demon demon)
    {

    }
}
