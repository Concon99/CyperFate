using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leveltransation : MonoBehaviour
{
    public int sceneBuildIntext; // Creating the scene building
    public Animator transation;
    public float transationTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
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