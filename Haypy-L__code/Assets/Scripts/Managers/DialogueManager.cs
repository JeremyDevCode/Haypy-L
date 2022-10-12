using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("Dependencies")]
    public DialogueUI dialogueUI;

    [Header("Action events")]
    public UnityEvent onConversationStarted;
    public UnityEvent onConversationEnded;

    private Queue<Sentence> sentences;

    private void Start()
    {
        this.sentences = new Queue<Sentence>();
    }

    public void StartConversation(ConversationSO conversation)
    {
        if (this.sentences.Count != 0)
            return;

        foreach (var sentence in conversation.sentences)
        {
            this.sentences.Enqueue(sentence);
        }

        this.dialogueUI.StartConversation(
            leftCharacterName: conversation.leftCharacter.fullname,
            leftCharacterPortrait: conversation.leftCharacter.portrait,
            rightCharacterName: conversation.rightCharacter.fullname,
            rightCharacterPortrait: conversation.rightCharacter.portrait
        );

        if (this.onConversationStarted != null)
            this.onConversationStarted.Invoke();

        this.NextSentence();
    }

    public void NextSentence()
    {
        if (this.dialogueUI.IsSentenceInProcess())
        {
            this.dialogueUI.FinishDisplayingSentence();
            return;
        }

        if (this.sentences.Count == 0)
        {
            this.EndConversation();
            return;
        }

        var sentence = this.sentences.Dequeue();
        this.dialogueUI.DisplaySentence(
            characterName: sentence.character.fullname,
            sentenceText: sentence.text
        );
    }

    public void EndConversation()
    {
        this.dialogueUI.EndConversation();

        if (this.onConversationEnded != null)
            this.onConversationEnded.Invoke();
    }
}
