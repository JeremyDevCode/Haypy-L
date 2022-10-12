using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;


[System.Serializable]
public class InventoryConsumable
{
    public ItemConsumableSO item;
    public int amount;

    public InventoryConsumable(ItemConsumableSO item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}

[CreateAssetMenu(fileName = "NewInventory", menuName = "Scriptable Objects/Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    [Header("Gold")]
    public int gold = 0;
    public int hearts = 3;
    public int currentLevel = 1;

    [Header("Weapons")]
    public List<ItemWeaponSO> weapons = new List<ItemWeaponSO>(2);

    [Header("Consumables")]
    public List<InventoryConsumable> consumables = new List<InventoryConsumable>(2);



    // Public functions

    public void AddGold(int gold)
    {
        this.gold += Mathf.Abs(gold);
    }
    public void AddHearts(int hearts)
    {
        this.hearts = hearts;
    }
    public void AddLevel(int currentLevel)
    {
        this.currentLevel = currentLevel;
    }

    public void GetGold(int gold)
    {
        this.gold -= Mathf.Abs(gold);
    }

    public bool AddWeapon(ItemWeaponSO weapon)
    {
        if (!this.weapons.Contains(weapon) && this.weapons.Count < 2)
        {
            this.weapons.Add(weapon);
            return true;
        }

        return false;
    }

    public bool RemoveWeapon(ItemWeaponSO weapon)
    {
        bool removed = this.weapons.Remove(weapon);

        return removed;
    }

    public bool AddConsumable(ItemConsumableSO consumable)
    {
        var consumableFound = this.consumables.Find((c) => { return c.item.itemName == consumable.itemName; });

        if (consumableFound != null)
        {
            consumableFound.amount += 1;
        }
        else
        {
            var newInventoryConsumable = new InventoryConsumable(consumable, 1);
            this.consumables.Add(newInventoryConsumable);
        }

        return true;
    }

    public bool RemoveConsumable(ItemConsumableSO consumable)
    {
        var consumableFound = this.consumables.Find((c) => { return c.item.itemName == consumable.itemName; });
        bool removed = false;

        if (consumableFound != null)
        {
            consumableFound.amount -= 1;

            if (consumableFound.amount == 0)
            {
                removed = this.consumables.Remove(consumableFound);
            }
        }

        return removed;
    }
}
