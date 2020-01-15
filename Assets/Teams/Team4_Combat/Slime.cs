using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public sealed class Slime : Enemy
{
    Vector3 mRandomDirection;

    float mRandomDirectionCooldown = 1.0f;
    float mRandomDirectionTracker;

    NavMeshAgent agent;

    protected override void CreateLootTable()
    {
        for (int i = 0; i < 1; i++)
        {
            mLootTable.Add(new HealthPotion());
            mLootTable.Add(new FireHappy());
            mLootTable.Add(new Frostmourne());
        }

        Debug.Log("Slime's loot table:" + mLootTable.Count);
        foreach (var item in mLootTable)
        {
            Debug.Log(item.GetType().Name);
        }
    }

    private void Start()
    {
        base.Start();
        SetRandomDirection();
        mAttackCooldown = 2.0f;
        CreateLootTable();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Movement());
    }

    void SetRandomDirection()
    {
        mRandomDirection = new Vector3(Random.Range(-5, 5), transform.position.y, Random.Range(-5, 5));
        mRandomDirection.y = 0;
    }

    private void FixedUpdate()
    {
        base.FixedUpdate();
        //Move();
        //mCurrentHP--;
    }

    private void Update()
    {
        base.Update();
    }


    public override void Attack(Player player)
    {
        player.TakeDamage(mAttack);
    }

    public override void Move()
    {
        if(mRandomDirectionTracker > mRandomDirectionCooldown)
        {
            SetRandomDirection();
            mRandomDirectionTracker = 0.0f;
        }
        else
        {
            transform.position += mRandomDirection * Time.deltaTime;
        }
        if (mRandomDirectionTracker < 10f)
            mRandomDirectionTracker += Time.deltaTime;       
    }

    IEnumerator Movement()
    {
        Vector3 targetDestination = transform.position + mRandomDirection;
        agent.SetDestination(targetDestination);
        while (true)
        {
            if (Vector3.Distance(transform.position, targetDestination) <= 0.2f)
            {
                SetRandomDirection();             
                targetDestination = transform.position + mRandomDirection;
                agent.SetDestination(targetDestination);
            }
            yield return null;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player && (mAttackTracker > mAttackCooldown))
        {
            Attack(player);
            mAttackTracker = 0.0f;
        }
    }
}
