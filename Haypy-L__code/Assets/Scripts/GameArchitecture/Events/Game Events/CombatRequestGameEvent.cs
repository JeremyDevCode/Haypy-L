using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "CombatRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Combat Request",
	    order = 120)]
	public sealed class CombatRequestGameEvent : GameEventBase<CombatRequest>
	{
	}
}