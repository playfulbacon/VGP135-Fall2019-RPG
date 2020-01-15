using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Required Function from other team
// [Character Status] GetMovementSpeed()

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float rotationSpeed = 20.0f;
    private NavMeshAgent agent;
    private bool isMoving;

    public bool isAutoPlay = false;
    private AttackManager attackManager;
    Player player;
    public float wanderRange = 200.0f;
    public float wanderDelay = 5.0f;
    private float delayTimer;

    // - Getter & Setter -----------------------------------------------------------------------
    public bool IsMoving        { get { return isMoving; }}
    public NavMeshAgent Agent   { get { return agent;    }}

    // - MonoBehavior functions ----------------------------------------------------------------
    void Awake()
    {
        // speed = GetComponent<CharacterStatus>().GetMovementSpeed();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        attackManager = gameObject.GetComponent<AttackManager>();
        player = GetComponent<Player>();
        delayTimer = wanderDelay;
    }

    void Update()
    {
        if (isAutoPlay)
        {
            AutoPlay();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 groundHit = hit.point;
                agent.isStopped = false;
                agent.destination = groundHit;
            }
        }

        isMoving = Vector3.SqrMagnitude(agent.velocity) > 1.0f;
    }

    public void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void ChangeAutoPlay()
    {
        isAutoPlay = !isAutoPlay;
    }

    public void AutoPlay()
    {
        //Justin Tim - Final - Added autoplay, wander and attack range
        Enemy target = attackManager.ReturnCurrentClosestEnemy();
        if (target && Vector3.Distance(target.transform.position, transform.position) >= attackManager.attackRange)
        {
            agent.isStopped = false;
            agent.destination = target.transform.position;
        }
        else if (target && Vector3.Distance(target.transform.position, transform.position) < attackManager.attackRange)
        {
            agent.isStopped = true;
        }
        else 
        {
            delayTimer += Time.deltaTime;
            if(delayTimer >= wanderDelay || agent.destination == transform.position)
            {
                Vector3 randomDirection = Random.insideUnitSphere * wanderRange;
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, wanderRange, 1);
                agent.isStopped = false;
                agent.SetDestination(hit.position);
                delayTimer = 0;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
