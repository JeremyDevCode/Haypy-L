using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class InventorySOReference : BaseReference<InventorySO, InventorySOVariable>
	{
	    public InventorySOReference() : base() { }
	    public InventorySOReference(InventorySO value) : base(value) { }
	}
}