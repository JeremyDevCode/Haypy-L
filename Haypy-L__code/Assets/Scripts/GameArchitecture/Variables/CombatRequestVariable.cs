using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class CombatRequestEvent : UnityEvent<CombatRequest> { }

	[CreateAssetMenu(
	    fileName = "CombatRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Combat Request",
	    order = 120)]
	public class CombatRequestVariable : BaseVariable<CombatRequest, CombatRequestEvent>
	{
	}
}