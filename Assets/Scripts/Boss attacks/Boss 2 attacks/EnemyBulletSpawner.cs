using UnityEngine;
using System.Collections;

public class EnemyBulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int totalBullets = 15;
    public float bulletSpeed = 5f;
    public float bulletLife = 3f;
    public float minSpawnInterval = 0.1f;
    public float maxSpawnInterval = 0.5f;
    private int bulletsSpawned = 0;
    public float randomDelay;

    void Start()
    {
    }

    public void Attack1()
    {
        if (bulletsSpawned < totalBullets)
        {
            float randomDelay = Random.Range(minSpawnInterval, maxSpawnInterval);
            InvokeRepeating("SpawnHomingBullet", 0f, randomDelay);
            StartCoroutine(WaitForBulletsToFinish());
        }
    }

    private IEnumerator WaitForBulletsToFinish()
    {
        yield return new WaitUntil(() => bulletsSpawned >= totalBullets);
    }

    void SpawnHomingBullet()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        
        Destroy(bullet, bulletLife);

        bulletsSpawned++;

        if (bulletsSpawned >= totalBullets)
        {
            CancelInvoke("SpawnHomingBullet");
        }
    }
}