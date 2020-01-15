using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Frostmourne : Weapon
{
    public Frostmourne()
    {
        mAttack = 1000;
        mGrade = ItemGrade.mLegendary;
        CalculateDropChance();
    }
}
