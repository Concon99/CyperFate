using UnityEngine;
using System.Collections;

public class B1Attack1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int totalBullets = 15;
    public float bulletSpeed = 5f;
    public float bulletLife = 3f;
    public float minSpawnInterval = 0.1f;
    public float maxSpawnInterval = 0.5f;
    public float minYPosition = -2f;
    public float maxYPosition = 2f;
    private int bulletsSpawned = 0;

    public AudioSource BulletSound;

    void Start()
    {
        // Set up repeating invocation in Start

    }

    public void Attack1()
    {
        InvokeRepeating("SpawnBullet", 0f, Random.Range(minSpawnInterval, maxSpawnInterval));
        // Reset bulletsSpawned when needed
        bulletsSpawned = 0;
    }

    void SpawnBullet()
    {
        if (bulletsSpawned < totalBullets)
        {
            BulletSound.Play();
            float randomYPosition = Random.Range(minYPosition, maxYPosition);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomYPosition, transform.position.z);

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
            Destroy(bullet, bulletLife);

            bulletsSpawned++;
        }
        else
        {
            // Cancel invocation when totalBullets is reached
            CancelInvoke("SpawnBullet");
        }
    }
}