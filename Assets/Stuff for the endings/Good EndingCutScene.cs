using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoodEndingCutScene : MonoBehaviour
{
    public int sceneBuildIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutSceneEnd());
    }



    IEnumerator CutSceneEnd()
    {
        yield return new WaitForSeconds(31);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
    }
}

