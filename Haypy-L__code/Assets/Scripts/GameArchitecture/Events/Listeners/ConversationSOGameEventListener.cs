using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "ConversationSO")]
	public sealed class ConversationSOGameEventListener : BaseGameEventListener<ConversationSO, ConversationSOGameEvent, ConversationSOUnityEvent>
	{
	}
}