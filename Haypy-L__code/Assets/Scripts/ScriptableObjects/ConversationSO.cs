using UnityEngine;

[System.Serializable]
public class Sentence
{
    public CharacterSO character;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "NewConversation", menuName = "Scriptable Objects/Conversation/Conversation")]
public class ConversationSO : ScriptableObject
{
    public CharacterSO leftCharacter;
    public CharacterSO rightCharacter;
    public Sentence[] sentences;
}
