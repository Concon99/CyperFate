using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Added using directive for UI elements

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    public Image characterIcon; // Added variable for character icon

    private Queue<DialogueLine> lines = new Queue<DialogueLine>();
    public bool isDialogueActive = false;
    public float typingSpeed = 0.2f;
    public Animator animator;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        animator.Play("show");
        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine currentLine = lines.Dequeue();

        characterName.text = currentLine.character.name;

        // Check if the characterIcon variable is not null
        if (characterIcon != null)
        {
            // Set the character's icon on the UI Image
            characterIcon.sprite = currentLine.character.icon;
        }
        else
        {
            Debug.LogError("Character Icon UI is not assigned in the Inspector!");
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");
    }
}