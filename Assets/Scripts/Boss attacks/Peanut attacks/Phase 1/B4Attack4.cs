using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4Attack4 : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public AudioSource Static;


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
        

        // Wait for 3 seconds
        Static.Play();
        yield return new WaitForSeconds(8);

        // Make the UI invisible again
        canvasGroup.alpha = 0f;
    }


}