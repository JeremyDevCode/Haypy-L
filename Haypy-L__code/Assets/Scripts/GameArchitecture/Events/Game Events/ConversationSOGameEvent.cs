using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "ConversationSOGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Conversation Request",
	    order = 120)]
	public sealed class ConversationSOGameEvent : GameEventBase<ConversationSO>
	{
	}
}