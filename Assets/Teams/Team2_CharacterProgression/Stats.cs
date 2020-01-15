using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Basic Stats
    int baseStrength = 10;
    int currentStrength;

    int baseIntelligence = 10;
    int currentIntelligence;

    int baseConstitution = 10;
    int currentConstition;

    int baseWisdom = 10;
    int currentWisdom;

    int baseDexterity = 10;
    int currentDexterity;


    // Secondary Stats
    float physicalDamage = 100;
    float attackSpeed = 0.1f;
    public float AttackSpeed { get { return attackSpeed; } }

    float spellDamage = 100;
    int maxMagicPoints = 100;
    int currentMagicPoints = 100;

    float maxHealth = 100;
    float currentHealth = 100;

    int leftoverStatPoints = 0;


    /// Strength Functions ----------------------------------------------------------
    public int GetBaseStrength()
    {
        return baseStrength;
    }
    public int GetCurrentStrength()
    {
        return currentStrength;
    }
    public void ModifyBaseStrength(int n)
    {
        baseStrength += n;
        CalculatePhysicalDamage();
    }
    void CalculatePhysicalDamage()
    {
        physicalDamage = 100 + (currentStrength * 5);      // % based damage. Each point increases physical damage by 5%
    }



    /// Intelligence Functions ------------------------------------------------------
    public int GetBaseIntelligence()
    {
        return baseIntelligence;
    }
    public int GetCurrentIntelligence()
    {
        return currentIntelligence;
    }
    public void ModifyBaseIntelligence(int n)
    {
        baseIntelligence += n;

    }
    void CalculateSpellDamage()
    {
        spellDamage = 100 + (currentIntelligence * 5);      // % based damage. Each point increases spell damage by 5%
    }



    /// Constitution Functions ------------------------------------------------------
    // Returns the base Constitution score before modifiers
    public int GetBaseConstitution()
    {
        return baseConstitution;
    }
    public int GetCurrentConstitution()
    {
        return currentConstition;
    }
    public void ModifyBaseConstitution(int n)
    {
        baseConstitution += n;
        CalculateMaxHealth();
    }
    void CalculateMaxHealth()
    {
        maxHealth = 100 + (baseConstitution * 10); // Increase by 10 health per constitution point
    }



    /// Wisdom Functions ------------------------------------------------------------
    // Returns the base Wisdom before score modifiers
    public int GetBaseWisdom()
    {
        return baseWisdom;
    }
    public int GetCurrentWisdom()
    {
        return currentWisdom;
    }
    public void ModifyBaseWisdom(int n)
    {
        baseWisdom += n;
        CalculateMagicPoints();
    }
    void CalculateMagicPoints()
    {
        maxMagicPoints = 100 + (currentWisdom * 10);
    }



    /// Dexterity Functions ---------------------------------------------------------
    // Returns the base Dexterity stat before score modifiers
    public int GetBaseDexterity()
    {
        return baseDexterity;
    }
    public void ModifyBaseDexterity(int n)
    {
        baseDexterity += n;
    }
    // Returns the attackspeed of the character based off of dexterity
    void CalculateAttackSpeed()
    {
        attackSpeed = 10 / currentDexterity;
    }


    public int GetStatPointsToSpend()
    {
        return leftoverStatPoints;
    }
    public void SetNumberStatPointsToSpend(int n)
    {
        leftoverStatPoints = n;
    }
}