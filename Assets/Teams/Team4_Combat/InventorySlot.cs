using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventorySlot : MonoBehaviour
{
    protected Inventory inven;
    public int mID;

    private void Awake()
    {
        inven = GetComponentInParent<Inventory>();
    }
}
