using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Test vars
    bool canAttack = false;

    Stats stats;

    public GameObject autoAttackObject;

    int currentExperience = 0;
    int nextLevelExperienceRequired = 10;

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        print("take damage");
    }

    public float GetAttackSpeed()
    {
        return stats.AttackSpeed;
    }
    public void LevelUpStats()
    {

        // Allow user to level up as well

    }
    public void GiveExperience(int xpAmount)
    {
        currentExperience += xpAmount;
        if (currentExperience >= nextLevelExperienceRequired)
        {
            LevelUpStats();
        }
    }
    public void AutoAttack(Enemy enemyTarget)
    {
        Debug.Log("auto attack");
        // Instantiate an arrow object with a forward vector facing the enemyTarget position. Then gives the target var of the arrow the enemy GameObject enemyTarget
        Vector3 direction = enemyTarget.transform.position - transform.position;
        direction.Normalize();
        GameObject go = Instantiate(autoAttackObject, transform.position + (direction * 1.0f), Quaternion.identity);
        go.transform.forward = direction;
        go.GetComponent<Arrow>().Target = enemyTarget.gameObject;
    }
}
