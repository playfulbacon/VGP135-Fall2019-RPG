using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Weapon mEquippedWeapon;
    Armor mEquippedArmor;

    List<Item> items = new List<Item>();

    public GameObject mConsumablePrefab;
    public GameObject mEquipmentPrefab;
    Sprite weaponImage;
    Sprite armorImage;

    GameObject[] inventoryItems;

    private void Awake()
    {
        weaponImage = Resources.Load<Sprite>("sword");
        armorImage = Resources.Load<Sprite>("armor");
        inventoryItems = new GameObject[items.Count];
    }

    public int GetEquippedWeaponAttack()
    {
        if (mEquippedWeapon)
            return mEquippedWeapon.GetWeaponAttack();
        else
            return 0;
    }
    public int GetEquippedArmorDefense()
    {
        if (mEquippedArmor)
            return mEquippedArmor.GetArmorDefense();
        else
            return 0;
    }

    void GenerateInventoryIcons()
    {
        foreach (var item in inventoryItems)
        {
            Destroy(item);
        }
        inventoryItems = new GameObject[items.Count];
        int count = 0;
        foreach (var item in items)
        {
            if(item is Consumable)
            {
                inventoryItems[count] = Instantiate(mConsumablePrefab, transform);
                Consumable tempItem = item as Consumable;
                inventoryItems[count].GetComponentInChildren<Text>().text = "X" + tempItem.GetItemCount();

                inventoryItems[count].GetComponent<ConsumableSlot>().mID = count++;
            }
            else if(item is Equipment)
            {
                inventoryItems[count] = Instantiate(mEquipmentPrefab, transform);
                if (item is Weapon)
                {
                    inventoryItems[count].GetComponentInChildren<Image>().sprite = weaponImage;
                    EquipmentCompare(item, count);
                }
                else if (item is Armor)
                {
                    inventoryItems[count].GetComponentInChildren<Image>().sprite = armorImage;
                    EquipmentCompare(item, count);
                }
                inventoryItems[count].GetComponent<EquipmentSlot>().mID = count++;
            }
        }
    }

    private void EquipmentCompare(Item item, int index)
    {
        Equipment equip = item as Equipment;
        Text text = inventoryItems[index].GetComponentInChildren<Text>();
        if (ReferenceEquals(equip, mEquippedWeapon) || ReferenceEquals(equip, mEquippedArmor))
        {
            text.text = "Equipped";
        }
        else
        {
            text.text = "";
        }
    }

    public void AddItemsToInventory(List<Item> loots)
    {
        foreach (var loot in loots)
        {
            AddItem(loot);
        }
        GenerateInventoryIcons();
    }

    private void AddItem(Item loot)
    {
        if (loot is Consumable)
        {
            foreach (var item in items)
            {
                if (item.GetType().Equals(loot.GetType()))
                {
                    var tempLoot = loot as Consumable;
                    var tempItem = item as Consumable;
                    tempItem.IncreaseItemCount(tempLoot.GetItemCount());
                    return;
                }
            }
            items.Add(loot);
        }
        else
        {
            items.Add(loot);
        }
    }

    public void UseItem(int index)
    {
        if (index < items.Count && items[index] is Consumable)
        {
            Consumable selectedItem = items[index] as Consumable;
            selectedItem.UseItem();
            if(selectedItem.GetItemCount() == 0)
            {
                items.Remove(items[index]);
            }
        }
        GenerateInventoryIcons();
    }

    public void EquipItem(int index)
    {
        Item selectedItem = items[index];
        if (index < items.Count && selectedItem is Weapon)
        {
            mEquippedWeapon = (Weapon)selectedItem;
            Debug.Log(mEquippedWeapon.GetWeaponAttack());

        }
        else if(index < items.Count && items[index] is Armor)
        {
            mEquippedArmor = (Armor)selectedItem;
            Debug.Log(mEquippedArmor.GetArmorDefense());
        }
        GenerateInventoryIcons();
    }

    public void UnEquipItem(int index)
    {
        Item selectedItem = items[index];
        if (index < items.Count && ReferenceEquals(selectedItem, mEquippedWeapon))
        {
            mEquippedWeapon = null;
        }
        else if(index < items.Count && ReferenceEquals(selectedItem, mEquippedArmor))
        {
            mEquippedArmor = null;
        }
        GenerateInventoryIcons();
    }
}
