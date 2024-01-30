using System.Collections;
using UnityEngine;

public class B4Attack2_3 : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f; // Time before the bullet is destroyed

    private Transform playerTransform;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        moveDirection = (playerTransform.position - transform.position).normalized;
        StartCoroutine(DestroyAfterLifetime());
    }

    // Update is called once per frame
    void Update()
    {
        // Move in a straight line
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}