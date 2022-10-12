using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "CombatRequest")]
	public sealed class CombatRequestGameEventListener : BaseGameEventListener<CombatRequest, CombatRequestGameEvent, CombatRequestUnityEvent>
	{
	}
}