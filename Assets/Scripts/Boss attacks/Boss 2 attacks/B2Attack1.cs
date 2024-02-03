using System.Collections;
using UnityEngine;

public class B2Attack1 : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;

    private Transform playerTransform;
    private Vector2 moveDirection;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        moveDirection = (playerTransform.position - transform.position).normalized;
        StartCoroutine(MoveAndDestroy());
    }

    IEnumerator MoveAndDestroy()
    {
        float elapsedTime = 0f;

        while (elapsedTime < lifetime)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}