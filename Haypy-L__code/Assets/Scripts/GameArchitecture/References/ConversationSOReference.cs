using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ConversationSOReference : BaseReference<ConversationSO, ConversationSOVariable>
	{
	    public ConversationSOReference() : base() { }
	    public ConversationSOReference(ConversationSO value) : base(value) { }
	}
}