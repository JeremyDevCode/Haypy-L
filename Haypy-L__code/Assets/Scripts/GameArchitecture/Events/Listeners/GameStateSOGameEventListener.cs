using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "GameStateSO")]
	public sealed class GameStateSOGameEventListener : BaseGameEventListener<GameStateSO, GameStateSOGameEvent, GameStateSOUnityEvent>
	{
	}
}