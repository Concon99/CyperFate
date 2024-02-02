using UnityEngine;
using System.Collections;

public class B1Attack2 : MonoBehaviour
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
    private Coroutine attackCoroutine; // Store the reference to the coroutine

    public AudioSource BulletSound;

    void Start()
    {
    }

    public void Attack2()
    {
        Debug.Log("Entering Attack2");

        if (attackCoroutine == null)
        {
            attackCoroutine = StartCoroutine(ContinuousAttack());
        }
    }

    private IEnumerator ContinuousAttack()
    {
        while (bulletsSpawned < totalBullets)
        {
            float randomDelay = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomDelay);

            SpawnBullet();
        }

        Debug.Log("Exiting Attack2");

        // Reset bulletsSpawned and the coroutine reference
        bulletsSpawned = 0;
        attackCoroutine = null;
    }

    void SpawnBullet()
    {
        BulletSound.Play();
        float randomYPosition = Random.Range(minYPosition, maxYPosition);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomYPosition, transform.position.z);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;
        Destroy(bullet, bulletLife);

        bulletsSpawned++;
    }
}