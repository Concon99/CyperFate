using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//I might have no idea what this means BUT this is basically making a long list of dialogue
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character; //creating the visual for the player
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool Hastriggered = false;




public void TriggerDialogue()
    {
        if (!Hastriggered) // Check if the dialogue has not been triggered yet
        {
            DialogueManager.Instance.StartDialogue(dialogue);
            Hastriggered = true; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            TriggerDialogue();
        }
    }
}