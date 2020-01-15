using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item
{
    protected bool mIsEquipped;

    public bool IsEquipped() { return mIsEquipped; }

    public void EquipItem() { mIsEquipped = true; }

    public void UnEquipItem() { mIsEquipped = false; }

    //temp variables, would have to be re-implemented based on player stats format
    protected int mStr;
    protected int mInt;
    protected int mCon;
}
