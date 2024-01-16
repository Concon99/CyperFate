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

    public void TriggerDialogue() 
    {
        DialogueManager.Instance.StartDialogue(dialogue); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            TriggerDialogue(); 
        }
    }
}