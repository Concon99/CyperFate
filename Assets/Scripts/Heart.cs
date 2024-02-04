using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public AudioSource Collect;

    private void Start()
    {

        StartCoroutine(Creation());
    }

    private IEnumerator Creation()
    {
        yield return StartCoroutine(PlayerInput());
        Destroy(gameObject);
    }

    private IEnumerator PlayerInput()
    {
        // Wait for the next frame before checking collisions
        yield return null;

        while (true) // Forever loop
        {
            yield return null; // Wait for the next frame
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect.Play();
            Debug.Log("Collected Heart");
            Destroy(gameObject);
        }
    }
}