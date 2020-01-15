using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSlot : InventorySlot
{
    public void UseItem()
    {
        inven.UseItem(mID);
    }
}
