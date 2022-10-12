using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [Header("Configuration")]
    public float textSpeed;

    [Header("Dependencies")]
    public GameObject ui;

    public GameObject leftCharacter;
    public GameObject rightCharacter;

    public TextMeshProUGUI leftCharacterName;
    public Image leftCharacterPortrait;
    public TextMeshProUGUI rightCharacterName;
    public Image rightCharacterPortrait;
    public TextMeshProUGUI dialogueBox;

    private string _currentSenence;

    public void StartConversation(
        string leftCharacterName,
        Sprite leftCharacterPortrait,
        string rightCharacterName,
        Sprite rightCharacterPortrait)
    {
        // Reset UI
        this.CleanUI();

        // Set images and names
        this.leftCharacterName.text = leftCharacterName;
        this.leftCharacterPortrait.sprite = leftCharacterPortrait;
        this.rightCharacterName.text = rightCharacterName;
        this.rightCharacterPortrait.sprite = rightCharacterPortrait;

        // Clean dialogue just in case
        this.dialogueBox.text = "";

        // Hide everything
        this.ToggleLeftCharacter(false);
        this.ToggleRightCharacter(false);
    }

    public void DisplaySentence(string characterName, string sentenceText)
    {
        if (characterName == leftCharacterName.text)
        {
            // Left character is talking
            this.ToggleLeftCharacter(true);
            this.ToggleRightCharacter(false);
        }
        else
        {
            // Right character is talking
            this.ToggleLeftCharacter(false);
            this.ToggleRightCharacter(true);
        }

        this._currentSenence = sentenceText;
        StartCoroutine(TypeCurrentSentence());
    }

    public void EndConversation()
    {
        this.CleanUI();
    }

    public bool IsSentenceInProcess()
    {
        return this._currentSenence != null;
    }

    public void FinishDisplayingSentence()
    {
        StopAllCoroutines();
        this.dialogueBox.text = this._currentSenence;
        this._currentSenence = null;
    }

    // Private Logic

    private IEnumerator TypeCurrentSentence()
    {
        this.dialogueBox.text = "";

        foreach (char letter in this._currentSenence.ToCharArray())
        {
            this.dialogueBox.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        this.dialogueBox.text = this._currentSenence;
        this._currentSenence = null;
    }

    private void CleanUI()
    {
        this.leftCharacterName.text = "";
        this.leftCharacterPortrait.sprite = null;
        this.rightCharacterName.text = "";
        this.rightCharacterPortrait.sprite = null;

        this.dialogueBox.text = "";
    }

    private void ToggleLeftCharacter(bool status)
    {
        this.leftCharacter.SetActive(status);
    }

    private void ToggleRightCharacter(bool status)
    {
        this.rightCharacter.SetActive(status);
    }
}
