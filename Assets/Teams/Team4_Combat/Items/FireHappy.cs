using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHappy : Armor
{
    public FireHappy()
    {
        mDefense = 1000;
        mGrade = ItemGrade.mRare;
        CalculateDropChance();
    }
}