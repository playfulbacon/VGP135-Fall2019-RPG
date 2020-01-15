using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HealthPotion : Consumable
{
    //int mRecoverAmount = 10;

    public override void UseItem()
    {
        if (mItemCount > 0)
        {
            ConsumeItem();
            Player player = FindObjectOfType<Player>();
            //if (player)
            //    player.Heal(mRecoverAmount);
        }
    }

    public HealthPotion()
    {
        mGrade = ItemGrade.mCommon;
        CalculateDropChance();
    }
}