using UnityEngine;
using ScriptableObjectArchitecture;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Configuration")]
    public ConversationSO conversation;

    [Header("Broadcasting events")]
    public ConversationSOGameEvent conversationRequestEvent;

    public void TriggerConversation()
    {
        this.conversationRequestEvent.Raise(this.conversation);
    }
}
