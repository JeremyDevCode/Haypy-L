using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "GameStateSOGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Game State Change",
	    order = 120)]
	public sealed class GameStateSOGameEvent : GameEventBase<GameStateSO>
	{
	}
}