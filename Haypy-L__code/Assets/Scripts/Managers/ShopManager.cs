using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour
{
    [Header("Dependencies")]
    public ShopUI shopUI;
    public InventorySO playerInventory;

    [Header("Shop Configuration")]
    public List<int> weaponPrices = new List<int>(2);
    public List<int> consumablePrices = new List<int>(2);

    [Header("Action events")]
    public UnityEvent onShopOpened;
    public UnityEvent onShopClosed;
    public UnityEvent onItemBought;

    private InventorySO _shopInventory;

    public void OpenShop(InventorySO shopInventory)
    {
        if (this._shopInventory != null)
            return;

        this._shopInventory = shopInventory;
        this.shopUI.SetupHUD(this._shopInventory, this.weaponPrices, this.consumablePrices, this.playerInventory);

        if (this.onShopOpened != null)
            this.onShopOpened.Invoke();
    }

    public void CloseShop()
    {
        this._shopInventory = null;

        if (this.onShopClosed != null)
            this.onShopClosed.Invoke();
    }

    public void BuyItem(int itemId)
    {
        // Weapons

        if (itemId == 0 || itemId == 1) // Player is trying to buy a weapon
        {
            var itemPrice = this.weaponPrices[itemId];

            if (this.playerInventory.gold < itemPrice) // No money no shopping
                return;

            var item = this._shopInventory.weapons[itemId];
            this.playerInventory.GetGold(itemPrice);
            this.playerInventory.AddWeapon(item);
        }


        // Consumables

        else if (itemId == 2 || itemId == 3) // Player is trying to buy a consumable
        {
            var consumableIndex = itemId % 2;
            var itemPrice = this.consumablePrices[consumableIndex];

            if (this.playerInventory.gold < itemPrice) // No money no shopping
                return;

            var shopItem = this._shopInventory.consumables[consumableIndex];
            this.playerInventory.GetGold(itemPrice);
            this.playerInventory.AddConsumable(shopItem.item);
            this._shopInventory.RemoveConsumable(shopItem.item);
        }

        if (this.onItemBought != null)
            this.onItemBought.Invoke();
    }
}
