using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brain_transation : MonoBehaviour
{
    public int sceneBuildIntext; // Creating the scene building
    public Animator transation;
    public float transationTime = 1f;
    [SerializeField] private DialogueManager _DialogueManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_DialogueManager.isDialogueActive && other.tag == "Player" )
        {
            if (_DialogueManager.Robotic_item)
            {
             sceneBuildIntext = 19;
            }
            if (!_DialogueManager.Robotic_item)
            {
             sceneBuildIntext = 20;
            }
            print("Trigger entered");
            transation.SetTrigger("Fadein"); // Causing the fade-in transition
            StartCoroutine(TransitionToScene(other));
        }
    }

    IEnumerator TransitionToScene(Collider2D other)
    {
        
        print("Switching scene to " + sceneBuildIntext); // Printing what scene we're loading to
        yield return new WaitForSeconds(transationTime);
        SceneManager.LoadScene(sceneBuildIntext, LoadSceneMode.Single); // Single so it loads one scene. Loading the scen
    }
}