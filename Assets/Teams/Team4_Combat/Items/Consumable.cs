using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : Item
{
    protected int mItemCount = 1;

    public int GetItemCount() { return mItemCount; }
    public void IncreaseItemCount(int count) { mItemCount += count; }
    protected void ConsumeItem()
    {   
        if(mItemCount > 0)
            mItemCount--;
    }

    public abstract void UseItem();
}