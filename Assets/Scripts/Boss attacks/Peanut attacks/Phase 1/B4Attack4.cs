using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4Attack4 : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.alpha = 0f;
    }

    public void Attack4()
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        // Make the UI visible
        canvasGroup.alpha = 0.6f;
        

        float waitTime = Random.Range(3,7);
        // Wait for 3 seconds
        yield return new WaitForSeconds(waitTime);

        // Make the UI invisible again
        canvasGroup.alpha = 0f;
    }


}