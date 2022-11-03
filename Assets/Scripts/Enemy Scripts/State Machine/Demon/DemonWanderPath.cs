using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonWanderPath : DemonBaseState
{ 
    private float timeStamp;
    private float dist;

    [SerializeField] private int waypointIndex;
    
    public override void Start(StateMachine_Demon demon)
    {
        waypointIndex = 0;
    }

    public override void EnterState(StateMachine_Demon demon)
    {
        //NONE
    }

    public override void UpdateState(StateMachine_Demon demon)
    {
        dist = Vector2.Distance(demon.transform.position, demon.waypoints[waypointIndex].position);
        if(dist < 0.25f)
        {
            IncreaseIndex(demon);

            //Enemy will wait a little bit before moving onto the next waypoint.
            demon.StartChildCoroutine(wait(demon));

            
        }

        //Set the destination setter to the current waypoint index.
        demon.dSetter.target = demon.waypoints[waypointIndex];


    }
   
    public override void FixedUpdateState(StateMachine_Demon demon)
    {
        //NONE
    }

    public override void OnTriggerEnter(StateMachine_Demon demon, Collider2D collider)
    {
        //NONE
    }

    public override void LeaveState(StateMachine_Demon demon)
    {

    }

    private void IncreaseIndex(StateMachine_Demon demon)
    {
        //Increase the index
        waypointIndex++;

        //If the demon has reached its final destination, start at 0; making it do a loop.
        if(waypointIndex >= demon.waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    IEnumerator wait(StateMachine_Demon demon)
    {
        demon.animator.SetBool("running", false);
        demon.path.canMove = false;
        yield return new WaitForSeconds(demon.timeBeforeMoving);
        demon.animator.SetBool("running", true);
        demon.path.canMove = true;
        
    }
}
