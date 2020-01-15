using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Armor : Equipment
{
    protected int mDefense;

    public int GetArmorDefense() { return mDefense; }
}