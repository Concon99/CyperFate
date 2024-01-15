using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//IN ORDER TO ACESS SCENES GO TO BUILD SETTINGS there you can see the scene numbers so when transationing you'll know what numbers to transation through.


public class NewBehaviourScript : MonoBehaviour
{
    public int sceneBuildIntext; //creating the scene buidling
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        print("Trigger entered");


        if(other.tag == "Player") //Checking if other from the triggerentertd is player
        {
            print("Switching scene to " + sceneBuildIntext); //printing what scene were loading too
            SceneManager.LoadScene(sceneBuildIntext, LoadSceneMode.Single); //single so it loads one scene. Loading the scene
        }
    }

}
