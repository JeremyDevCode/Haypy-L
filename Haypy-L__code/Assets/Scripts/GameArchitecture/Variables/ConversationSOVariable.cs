using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class ConversationSOEvent : UnityEvent<ConversationSO> { }

	[CreateAssetMenu(
	    fileName = "ConversationSOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Conversation Request",
	    order = 120)]
	public class ConversationSOVariable : BaseVariable<ConversationSO, ConversationSOEvent>
	{
	}
}