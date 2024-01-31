using UnityEngine;
using System.Collections;

public class B4Attack2_2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float bulletLife = 3f;
    public float minSpawnInterval = 0.1f;
    public float maxSpawnInterval = 0.5f;
    public float rotationSpeed = 5f;
    private Transform playerTransform;


    void Start()
    {
        StartShooting(); // Start shooting when the script begins
    }

    void StartShooting()
    {
        // Start shooting bullets repeatedly
        InvokeRepeating("SpawnHomingBullet", 0f, Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnHomingBullet()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Destroy(bullet, bulletLife);
    }

    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 directionToPlayer = playerTransform.position - transform.position; // Assigning vector3 to player
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, -directionToPlayer) * Quaternion.Euler(0, 0, -90);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void Phase2()
    {
        Destroy(gameObject);
    }
}