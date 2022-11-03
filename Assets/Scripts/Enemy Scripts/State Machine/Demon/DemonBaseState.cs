using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DemonBaseState
{
    public abstract void Start(StateMachine_Demon demon);
    public abstract void UpdateState(StateMachine_Demon demon);
    public abstract void EnterState(StateMachine_Demon demon);
    public abstract void LeaveState(StateMachine_Demon demon);
    public abstract void FixedUpdateState(StateMachine_Demon demon);
    public abstract void OnTriggerEnter(StateMachine_Demon demon, Collider2D other);
}
