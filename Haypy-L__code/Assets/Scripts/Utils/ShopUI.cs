using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Dependencies")]

    // Shop Inventory
    public Button shopFirstWeaponButton;
    public Image shopFirstWeaponImage;
    public TextMeshProUGUI shopFirstWeaponNameText;
    public TextMeshProUGUI shopFirstWeaponCostText;

    public Button shopSecondWeaponButton;
    public Image shopSecondWeaponImage;
    public TextMeshProUGUI shopSecondWeaponNameText;
    public TextMeshProUGUI shopSecondWeaponCostText;

    public Button shopFirstConsumableButton;
    public Image shopFirstConsumableImage;
    public TextMeshProUGUI shopFirstConsumableAmountText;
    public TextMeshProUGUI shopFirstConsumableNameText;
    public TextMeshProUGUI shopFirstConsumableCostText;

    public Button shopSecondConsumableButton;
    public Image shopSecondConsumableImage;
    public TextMeshProUGUI shopSecondConsumableAmountText;
    public TextMeshProUGUI shopSecondConsumableNameText;
    public TextMeshProUGUI shopSecondConsumableCostText;


    // Player Inventory

    public Image playerFirstWeaponImage;

    public Image playerSecondWeaponImage;

    public Image playerFirstConsumableImage;
    public TextMeshProUGUI playerFirstConsumableAmountText;

    public Image playerSecondConsumableImage;
    public TextMeshProUGUI playerSecondConsumableAmountText;

    public TextMeshProUGUI playerGoldText;


    private InventorySO _shopInventory;
    private List<int> _weaponPrices;
    private List<int> _consumablePrices;
    private InventorySO _playerInventory;

    // Public functions

    public void SetupHUD(InventorySO shopInventory, List<int> weaponPrices, List<int> consumablePrices, InventorySO playerInventory)
    {
        this.ResetShopHUD();
        this.ResetPlayerHUD();

        this._shopInventory = shopInventory;
        this._weaponPrices = weaponPrices;
        this._consumablePrices = consumablePrices;
        this._playerInventory = playerInventory;

        // Disable buttons just in case
        this.shopFirstWeaponButton.interactable = false;
        this.shopSecondWeaponButton.interactable = false;
        this.shopFirstConsumableButton.interactable = false;
        this.shopSecondConsumableButton.interactable = false;

        // Shop items
        this.ConfigureShopWeapons();
        this.ConfigureShopConsumables();

        // Player items
        this.ConfigurePlayerWeapons();
        this.ConfigurePlayerConsumables();
        this.ConfigurePlayerGold();
    }



    // Private

    private void Update()
    {
        if (this._shopInventory == null || this._playerInventory == null)
            return;

        this.ConfigureShopConsumables();

        this.ConfigurePlayerWeapons();
        this.ConfigurePlayerConsumables();
        this.ConfigurePlayerGold();
    }



    private void ConfigureShopWeapons()
    {
        for (int weaponIndex = 0; weaponIndex < this._shopInventory.weapons.Count; weaponIndex++)
        {
            var weaponItem = this._shopInventory.weapons[weaponIndex];
            var weaponPrice = this._weaponPrices[weaponIndex];

            if (weaponIndex == 0)
            {
                this.shopFirstWeaponImage.sprite = weaponItem.icon;
                this.shopFirstWeaponImage.color = Color.white;
                this.shopFirstWeaponNameText.text = weaponItem.itemName;
                this.shopFirstWeaponCostText.text = weaponPrice.ToString();
                this.shopFirstWeaponButton.interactable = true;
            }
            if (weaponIndex == 1)
            {
                this.shopSecondWeaponImage.sprite = weaponItem.icon;
                this.shopSecondWeaponImage.color = Color.white;
                this.shopSecondWeaponNameText.text = weaponItem.itemName;
                this.shopSecondWeaponCostText.text = weaponPrice.ToString();
                this.shopSecondWeaponButton.interactable = true;
            }
        }
    }



    private void ConfigureShopConsumables()
    {

        for (int consumableIndex = 0; consumableIndex < this._shopInventory.consumables.Count; consumableIndex++)
        {
            var consumableItem = this._shopInventory.consumables[consumableIndex];
            var consumablePrice = this._consumablePrices[consumableIndex];

            if (consumableIndex == 0)
            {
                this.shopFirstConsumableImage.sprite = consumableItem.item.icon;
                this.shopFirstConsumableImage.color = Color.white;
                this.shopFirstConsumableNameText.text = consumableItem.item.itemName;
                this.shopFirstConsumableAmountText.text = consumableItem.amount.ToString();
                this.shopFirstConsumableCostText.text = consumablePrice.ToString();

                this.shopFirstConsumableButton.interactable = (consumableItem.amount > 0);
            }

            if (consumableIndex == 1)
            {
                this.shopSecondConsumableImage.sprite = consumableItem.item.icon;
                this.shopSecondConsumableImage.color = Color.white;
                this.shopSecondConsumableNameText.text = consumableItem.item.itemName;
                this.shopSecondConsumableAmountText.text = consumableItem.amount.ToString();
                this.shopSecondConsumableCostText.text = consumablePrice.ToString();

                this.shopSecondConsumableButton.interactable = (consumableItem.amount > 0);
            }
        }
    }



    private void ConfigurePlayerWeapons()
    {
        if (this._playerInventory.weapons.Count > 1)
        {
            // Player has 2 weapons
            var weaponItem = this._playerInventory.weapons[1];

            this.playerSecondWeaponImage.sprite = weaponItem.icon;
            this.playerSecondWeaponImage.color = Color.white;
        }
        else
        {
            this.playerSecondWeaponImage.sprite = null;
            this.playerSecondWeaponImage.color = Color.clear;
        }

        if (this._playerInventory.weapons.Count > 0)
        {
            // Player has 1 weapon
            var weaponItem = this._playerInventory.weapons[0];

            this.playerFirstWeaponImage.sprite = weaponItem.icon;
            this.playerFirstWeaponImage.color = Color.white;
        }
        else
        {
            this.playerFirstWeaponImage.sprite = null;
            this.playerFirstWeaponImage.color = Color.clear;
        }
    }



    private void ConfigurePlayerConsumables()
    {
        if (this._playerInventory.consumables.Count > 1)
        {
            // Player has 2 weapons
            var consumableItem = this._playerInventory.consumables[1];

            this.playerSecondConsumableImage.sprite = consumableItem.item.icon;
            this.playerSecondConsumableImage.color = Color.white;
            this.playerSecondConsumableAmountText.text = consumableItem.amount.ToString();
        }
        else
        {
            this.playerSecondConsumableImage.sprite = null;
            this.playerSecondConsumableImage.color = Color.clear;
            this.playerSecondConsumableAmountText.text = null;
        }

        if (this._playerInventory.consumables.Count > 0)
        {
            // Player has 1 weapon
            var consumableItem = this._playerInventory.consumables[0];

            this.playerFirstConsumableImage.sprite = consumableItem.item.icon;
            this.playerFirstConsumableImage.color = Color.white;
            this.playerFirstConsumableAmountText.text = consumableItem.amount.ToString();
        }
        else
        {
            this.playerFirstConsumableImage.sprite = null;
            this.playerFirstConsumableImage.color = Color.clear;
            this.playerFirstConsumableAmountText.text = null;
        }
    }



    private void ConfigurePlayerGold()
    {
        this.playerGoldText.text = this._playerInventory.gold.ToString();
    }



    private void ResetShopHUD()
    {
        this.shopFirstWeaponImage.sprite = null;
        this.shopFirstWeaponImage.color = Color.clear;
        this.shopFirstWeaponNameText.text = "-";
        this.shopFirstWeaponCostText.text = "-";
        this.shopFirstWeaponButton.interactable = false;

        this.shopSecondWeaponImage.sprite = null;
        this.shopSecondWeaponImage.color = Color.clear;
        this.shopSecondWeaponNameText.text = "-";
        this.shopSecondWeaponCostText.text = "-";
        this.shopSecondWeaponButton.interactable = false;

        this.shopFirstConsumableImage.sprite = null;
        this.shopFirstConsumableImage.color = Color.clear;
        this.shopFirstConsumableNameText.text = "-";
        this.shopFirstConsumableAmountText.text = "-";
        this.shopFirstConsumableCostText.text = "-";
        this.shopFirstConsumableButton.interactable = false;
    
        this.shopSecondConsumableImage.sprite = null;
        this.shopSecondConsumableImage.color = Color.clear;
        this.shopSecondConsumableNameText.text = "-";
        this.shopSecondConsumableAmountText.text = "-";
        this.shopSecondConsumableCostText.text = "-";
        this.shopSecondConsumableButton.interactable = false;
    }



    private void ResetPlayerHUD()
    {
        this.playerFirstWeaponImage.sprite = null;
        this.playerFirstWeaponImage.color = Color.clear;

        this.playerSecondWeaponImage.sprite = null;
        this.playerSecondWeaponImage.color = Color.clear;

        this.playerFirstConsumableImage.sprite = null;
        this.playerFirstConsumableImage.color = Color.clear;
        this.playerFirstConsumableAmountText.text = null;

        this.playerSecondConsumableImage.sprite = null;
        this.playerSecondConsumableImage.color = Color.clear;
        this.playerSecondConsumableAmountText.text = null;

        this.playerGoldText.text = "-";
    }
}
