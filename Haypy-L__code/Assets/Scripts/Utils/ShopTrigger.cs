using UnityEngine;
using ScriptableObjectArchitecture;

public class ShopTrigger : MonoBehaviour
{
    [Header("Configuration")]
    public InventorySO shopInventory;

    [Header("Broadcasting events")]
    public InventorySOGameEvent shopRequestEvent;

    public void TriggerShop()
    {
        this.shopRequestEvent.Raise(this.shopInventory);
    }
}
