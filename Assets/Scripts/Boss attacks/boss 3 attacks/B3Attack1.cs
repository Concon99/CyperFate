using System.Collections;
using UnityEngine;

public class B3Attack1 : MonoBehaviour
{
    private Transform playerTransform;
    public float rotationSpeed = 5f;
    public float rotationTime = 5f; // Adjusted rotation time
    public GameObject TinyBulletPreFab;
    public int initialBullets = 5; // Initial number of bullets

    private int Bulletsleft; // Number of bullets left


    void Start()
    {
        Bulletsleft = initialBullets; // Initialize Bulletsleft
    }

    public IEnumerator Attack1()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assign a valid reference
        StartCoroutine(TinyBullets());
        float elapsedTime = 0f;

        while (elapsedTime < rotationTime) // Time that the bullets shoot
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position; // Assigning vector3 to player
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, -directionToPlayer); // Making the object lock
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.identity; // Sets rotation to default
        Bulletsleft = initialBullets; // Reset Bulletsleft to the initial value
    }

    IEnumerator TinyBullets()
    {
        while (Bulletsleft > 0)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject TinyBullet = Instantiate(TinyBulletPreFab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Bulletsleft--;
        }
    }
}