using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Conversation/Character")]
public class CharacterSO : ScriptableObject
{
    public string fullname;
    public Sprite portrait;
}
