using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "InventorySO")]
	public sealed class InventorySOGameEventListener : BaseGameEventListener<InventorySO, InventorySOGameEvent, InventorySOUnityEvent>
	{
	}
}