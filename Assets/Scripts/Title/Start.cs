using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
     public int sceneBuildIndex = 5;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
