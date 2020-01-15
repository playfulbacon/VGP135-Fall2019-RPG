using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : InventorySlot
{

    public void Equip()
    {
        inven.EquipItem(mID);
    }

    public void Unequip()
    {
        inven.UnEquipItem(mID);
    }

}
