using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.InputSystem;

public class StateMachine : MonoBehaviour
{
    public enum State 
    { 
        Idle, 
        Moving, 
        Attack// MeleeAttack,
        //ProjectileAttack,
        //BeamAttack
    }

    public enum EnemyType
    {
        SpawnFail,
        Melee,
        Projectile,
        Beam
    }

    [Header("References")]
    
    // need to replace the GameObject declaration specifically with player script if we want to do fancier stuff
    [SerializeField] private GameObject player;
    [SerializeField] private AIPath pathfinder;
    [SerializeField] private AIDestinationSetter destinationSetter;
    [SerializeField] private ProjectileLauncher projectileLauncher;


    [Header("Settings")]
    [SerializeField] private State state;
    [SerializeField] private EnemyType enemyType;
    //[SerializeField] public Arcana arcanaType;
    [SerializeField] private InputAction startAction;

    //[SerializeField] public int waveID;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        destinationSetter = GetComponent<AIDestinationSetter>();
        projectileLauncher = GetComponent<ProjectileLauncher>();
        pathfinder = GameObject.FindWithTag("Pathfinding").GetComponent<AIPath>();

        startAction.performed += onStartAct;
        startAction.Enable();
    }

    void onStartAct(InputAction.CallbackContext ctx)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destinationSetter.target = player.transform;

        state = State.Moving;


        Debug.Log("Started AI");
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                //just some test code to make sure we're moving between states properly
                // not sure we even want an idle state but that depends on how we're spawning these guys
                
                pathfinder.canMove = false;

                break;
            
            case State.Moving:
                pathfinder.canMove = true;

                if (pathfinder.reachedDestination) {
                    state = State.Attack;
                }
                
                // switch (enemyType)
                // {
                //     case EnemyType.Melee:
                //         // if within distance, switch to relevant attack state
                //         break;

                //     case EnemyType.Projectile:
                //         // if within distance, switch to relevant attack state
                //         break;

                //     case EnemyType.Beam:
                //         // if within distance, switch to relevant attack state
                //         break;
                // }

                break;
            
            case State.Attack:
                //pathfinder.canMove = false;

                switch (enemyType)
                {
                    case EnemyType.Melee:
                        pathfinder.canMove = false;
                        // insert code to deal damage to player
                        // this guy needs a cooldown before he goes back to murdering you
                        break;

                    case EnemyType.Projectile:
                        // launch projectile
                        // the projectile itself will check if it hits/deals damage to player

                        projectileLauncher.Fire(true);
                        if (pathfinder.remainingDistance > 5)
                        {
                            projectileLauncher.Fire(false);
                            state = State.Moving;
                        }
                        
                        break;

                    case EnemyType.Beam:
                        // make sure to stop movement and lock rotation
                        // charge time on attack
                        // cast ray/rectangular hitbox, hitbox will check for collision and damage
                        break;
                }
                
                break;
        

            // case State.MeleeAttack:
            //     // insert code to deal damage to player
            //     // this guy needs a cooldown before he goes back to murdering you
            //     break;
            
            // case State.ProjectileAttack:
            //     // launch projectile
            //     // the projectile itself will check if it hits/deals damage to player
            //     break;
            
            // case State.BeamAttack:
            //     // make sure to stop movement and lock rotation
            //     // charge time on attack
            //     // cast ray/rectangular hitbox, hitbox will check for collision and damage
            //     break;
        }
    }
}
