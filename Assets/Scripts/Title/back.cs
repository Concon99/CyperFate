using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public int sceneBuildIndex = 0;
    // Start is called before the first frame update
    public void GoBack()
    {
        Debug.Log("RAHHHH");
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
