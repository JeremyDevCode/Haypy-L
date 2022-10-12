using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class InventorySOEvent : UnityEvent<InventorySO> { }

	[CreateAssetMenu(
	    fileName = "InventorySOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Shop Request",
	    order = 120)]
	public class InventorySOVariable : BaseVariable<InventorySO, InventorySOEvent>
	{
	}
}