using UnityEngine;
using System.Collections;


public class B1Attack1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int totalBullets = 15;
    public float bulletSpeed = 5f;
    public float bulletLife = 3f; // Adjust the bullet life duration
    public float minSpawnInterval = 0.1f; // Adjust the minimum spawn interval
    public float maxSpawnInterval = 0.5f; // Adjust the maximum spawn interval
    public float minYPosition = -2f; // Adjust the minimum Y position
    public float maxYPosition = 2f; // Adjust the maximum Y position
    private int bulletsSpawned = 0;

    void Start()
    {
    }

public void Attack1()
{

    if (bulletsSpawned < totalBullets)
    {
        float randomDelay = Random.Range(minSpawnInterval, maxSpawnInterval);
        InvokeRepeating("SpawnBullet", 0f, randomDelay);
        StartCoroutine(WaitForBulletsToFinish());
    }
}

private IEnumerator WaitForBulletsToFinish()
{
    yield return new WaitUntil(() => bulletsSpawned >= totalBullets);
    
}

    void SpawnBullet()
    {
        float randomYPosition = Random.Range(minYPosition, maxYPosition);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomYPosition, transform.position.z);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
        Destroy(bullet, bulletLife);

        bulletsSpawned++;

        if (bulletsSpawned >= totalBullets)
        {
            CancelInvoke("SpawnBullet");
        }
    }
}