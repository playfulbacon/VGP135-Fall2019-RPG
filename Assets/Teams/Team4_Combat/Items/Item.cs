using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemGrade
{
    mCommon,
    mRare,
    mLegendary,
}

public abstract class Item : MonoBehaviour
{
    protected ItemGrade mGrade;
    protected int mDropChance;

    public ItemGrade GetItemGrade() { return mGrade; }

    public int GetDropChance() { return mDropChance; }

    //in each item's start, needs to call this function to calculate drop chance
    protected void CalculateDropChance()
    {
        switch(mGrade)
        {
            case ItemGrade.mCommon:
                mDropChance = 50;
                break;
            case ItemGrade.mRare:
                mDropChance = 10;
                break;
            case ItemGrade.mLegendary:
                mDropChance = 1;
                break;
            default:
                break;
        }
    }
}
