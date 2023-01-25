using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StateMachine_Demon : MonoBehaviour
{
    [Header("AI")]
    public Transform[] waypoints;


    public float timeBeforeMoving = 1f;
    public float sightRange = 10f;
    public float attackRange = 5f;
    public float enemyRange = 0.2f;
    
    //States
    public DemonWanderPath wanderState = new DemonWanderPath();
    public DemonChase chaseState = new DemonChase();
    public DemonAttack attackState = new DemonAttack();
    //attack

    [SerializeField] private DemonBaseState currentState;

    [Header("Game Objects to set")]

    [Header("Animation")]
    public Animator animator;

    [Header("Attack")]
    public GameObject attackObject;

    [Header("Target Transform")]
    public Transform target;
    

    //Pseudo Private (states need to access these).
    [HideInInspector] public GameObject player;
    [HideInInspector] public AIDestinationSetter dSetter;
    [HideInInspector] public AIPath path;
    [HideInInspector] public EnemyRadialAttack attackScript;
    public bool enemyNearby;

    //Private
    private bool playerInSightRange;
    private bool playerInAttackRange;
    
    private Enemy enemyScript;
    private Rigidbody rb;
    


    private void Start()
    {
        //Get Components
        animator = GetComponent<Animator>();
        dSetter = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();
        enemyScript = GetComponent<Enemy>();
        attackScript = attackObject.GetComponent<EnemyRadialAttack>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");

        //Trigger the start function on all states
        wanderState.Start(this);

        //Set the starting state to wander.
        currentState = wanderState;
        currentState.EnterState(this);


    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);

        //1. Check the ranges
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, LayerMask.GetMask("Player"));
        playerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, LayerMask.GetMask("Player"));
    

        //2. Check if the player is in sight range, and not in attack range.
        if(playerInSightRange && !playerInAttackRange)
        {
            Debug.Log("Entering Chase State");
            SwitchState(chaseState);
        }

        //3. Check is player is in attack range.
        if(playerInAttackRange)
        {
            Debug.Log("Entering Attack State");
            SwitchState(attackState);
        }

 
    }

    public void SwitchState(DemonBaseState state)
    {   
        //Leave state function first then switch current state and finally enter state function.
        currentState.LeaveState(this);
        currentState = state;
        state.EnterState(this);
    }


    //To show the sight ranges for the enemy, basically what they see.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, enemyRange);

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Boundary")
        {
            Debug.Log("Demon is stuck");
            rb.isKinematic = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.isKinematic = false;
    }
    //States can't access these functions because they are not monobehaviour class so it's handled here.
    public void StartChildCoroutine(IEnumerator _coroutine)
    {
        StartCoroutine(_coroutine);
    }

    public void DestroyObject(GameObject _obj)
    {
        Destroy(_obj);
    }

    
}
