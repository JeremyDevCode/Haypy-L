using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveSystem", menuName = "Scriptable Objects/Save System")]
public class SaveSystem : ScriptableObject
{
	public string saveFilename = "savefile.sav";
	public string backupSaveFilename = "savefile.sav.bak";

	public InventorySO playerInventory;

	[HideInInspector] public SaveData saveData = new SaveData();



	// Save System Logic

	public void LoadSaveDataFromDisk()
	{
		if (FileManager.LoadFromFile(this.saveFilename, out var json))
		{
			this.saveData.FromJson(json);
			this.LoadSavedInventory();
		}
		else
        {
			this.CreateEmptySaveFile(); // Create empty file
			this.saveData.DefaultData(); // Create default data
			this.SaveDataToDisk(); // Save default data to file
			this.LoadSaveDataFromDisk(); // Call me again
        }
	}

	public void SaveDataToDisk()
	{
		if (FileManager.MoveFile(saveFilename, backupSaveFilename))
		{
			if (FileManager.WriteToFile(saveFilename, saveData.ToJson()))
			{
				Debug.Log("Save successful");
			}
		}
	}

	public void CreateEmptySaveFile()
	{
		FileManager.WriteToFile(saveFilename, "");
	}


	// Save System saving logic

	public void SaveInventory()
    {
		// Reset data and repopulate it with real info from the inventory
		this.saveData.ResetData();

		// Gold
		this.saveData.gold = this.playerInventory.gold;
		this.saveData.hearts = this.playerInventory.hearts;
		this.saveData.currentLevel = this.playerInventory.currentLevel;

		// Weapons
		foreach (var weapon in this.playerInventory.weapons)
		{
			this.saveData.weapons.Add(new SerializedItem(weapon.itemName, 1));
		}

		// Consumables
		foreach (var consumable in this.playerInventory.consumables)
		{
			this.saveData.consumables.Add(new SerializedItem(consumable.item.itemName, consumable.amount));
		}

		// Save to disk
		this.SaveDataToDisk();
	}

	public void LoadSavedInventory()
	{
		// Reset inventory and repopulate it with the info from the saved data
		this.playerInventory.gold = 0;
		this.playerInventory.weapons.Clear();
		this.playerInventory.consumables.Clear();

		// Gold
		this.playerInventory.gold = this.saveData.gold;
		this.playerInventory.hearts = this.saveData.hearts;
		this.playerInventory.currentLevel = this.saveData.currentLevel;
		// Weapons

		// Get all weapon scriptable objects that are in the "Resources" folder
		var weaponSOs = new List<ItemWeaponSO>(
			Resources.LoadAll<ItemWeaponSO>("InventoryItems/Weapons")
		);

		// For each item we have in the save data file...
		for (int weaponIndex = 0; weaponIndex < this.saveData.weapons.Count; weaponIndex++)
		{
			// Get the serialized data (the saved item info)
			var serializedWeapon = this.saveData.weapons[weaponIndex];
			// Get the actual Scriptable Object from the all we have from the folder
			var weaponSO = weaponSOs.Find((c) => { return c.itemName == serializedWeapon.itemName; });

			// If the scriptable object is actually there...
			if (weaponSO != null && !this.playerInventory.weapons.Contains(weaponSO))
			{
				// Put in in the inventory
				
				this.playerInventory.weapons.Insert(weaponIndex, weaponSO);
			}
		}


		// Consumables

		// Get all consumable scriptable objects that are in the "Resources" folder
		var consumablesSOs = new List<ItemConsumableSO>(
			Resources.LoadAll<ItemConsumableSO>("InventoryItems/Consumables")
		);

		// For each item we have in the save data file...
		for (int consumableIndex = 0; consumableIndex < this.saveData.consumables.Count; consumableIndex++)
		{
			// Get the serialized data (the saved item info)
			var serializedConsumable = this.saveData.consumables[consumableIndex];
			// Get the actual Scriptable Object from the all we have from the folder
			var consumableSO = consumablesSOs.Find((c) => { return c.itemName == serializedConsumable.itemName; });

			// If the scriptable object is actually there...
			if (consumableSO != null) {
				// Create a inventory consumable and put the correct amount
				var consumableItem = new InventoryConsumable(consumableSO, serializedConsumable.amount);

				if (!this.playerInventory.consumables.Contains(consumableItem))
				{
					// Then, put in in the inventory
					this.playerInventory.consumables.Insert(consumableIndex, consumableItem);
				}
			}
        }
	}
}