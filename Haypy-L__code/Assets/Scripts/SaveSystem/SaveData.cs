using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
	// Put the data you want to save in a file
	public int gold = 0;

	public int hearts = 3;

	public int currentLevel = 1;
	public List<SerializedItem> weapons = new List<SerializedItem>();
	public List<SerializedItem> consumables = new List<SerializedItem>();

	public void DefaultData()
    {
		this.ResetData();

		// Player needs at least one weapon
		var firstWeaponSO = Resources.Load<ItemWeaponSO>("InventoryItems/Weapons/FirstWeapon");

		if (firstWeaponSO != null)
        {
			this.weapons.Add(new SerializedItem(firstWeaponSO.itemName, 1));
		}
	}

	public void ResetData()
    {
		this.gold = 0;
		this.hearts = 3;
		this.currentLevel = 1;
		this.weapons.Clear();
		this.consumables.Clear();
    }

	public string ToJson()
	{
		return JsonUtility.ToJson(this);
	}

	public void FromJson(string json)
	{
		JsonUtility.FromJsonOverwrite(json, this);
	}
}