using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class GameStateSOEvent : UnityEvent<GameStateSO> { }

	[CreateAssetMenu(
	    fileName = "GameStateSOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Game State Change",
	    order = 120)]
	public class GameStateSOVariable : BaseVariable<GameStateSO, GameStateSOEvent>
	{
	}
}