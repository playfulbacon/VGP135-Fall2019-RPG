using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipment
{
    protected int mAttack;

    public int GetWeaponAttack() { return mAttack; }
}