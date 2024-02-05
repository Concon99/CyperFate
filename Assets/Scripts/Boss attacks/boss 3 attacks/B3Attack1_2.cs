using System.Collections;
using UnityEngine;

public class B2Attack1_2 : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f; // Time before the bullet is destroyed;
    public float alignDuration = 1f; // Duration to align with spawner before firing
    public float moveForwardDuration = 2f; // Duration to move forward after alignment

    private Vector2 moveDirection;
    private Transform spawner;

    public AudioSource DropSound;

    // Start is called before the first frame update
    void Start()
    {
        // Find the spawner object by tag
        GameObject spawnerObject = GameObject.FindGameObjectWithTag("arm");
        spawner = spawnerObject.GetComponent<Transform>();

        // Align with the spawner's direction before firing
        StartCoroutine(AlignWithSpawner());
    }

    IEnumerator AlignWithSpawner()
    {
        Debug.Log("AlignWithSpawner coroutine started");
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        // Adjust the target rotation by rotating more to the right (you can modify the angle)

        while (elapsedTime < alignDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Move forward after alignment
        StartCoroutine(MoveForwardAfterRotation());
    }

    IEnumerator MoveForwardAfterRotation()
    {
        DropSound.Play();
        Debug.Log("MoveForwardAfterRotation coroutine started");
        StartCoroutine(DestroyAfterLifetime());
        float elapsedTime = 0f;

        while (elapsedTime < moveForwardDuration)
        {
            // Move in a straight line
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Proceed with shooting or any other logic
    }

    IEnumerator DestroyAfterLifetime()
    {
        Debug.Log("DestroyAfterLifetime coroutine started");
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}