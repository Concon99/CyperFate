using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitButton : MonoBehaviour
{
    public int sceneBuildIndex = 0;
    // Start is called before the first frame update
    public void Quit()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
