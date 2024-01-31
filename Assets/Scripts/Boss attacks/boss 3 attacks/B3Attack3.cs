using UnityEngine;
using System.Collections;

public class B3Attack3 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int totalBullets = 15;
    public float bulletSpeed = 5f;
    public float minfallDuration = 3f;
    public float maxfallDuration = 3f;
    public float minSpawnInterval = 0.1f;
    public float maxSpawnInterval = 0.5f;
    public float minXPosition = -2f;
    public float maxXPosition = 2f;
    private int bulletsSpawned = 0;
    private Coroutine attackCoroutine; // Keep track of the running coroutine

    void Start()
    {
    }

    public void Attack3()
    {
        // Check if the coroutine is already running, and stop it if needed
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            ResetState();
        }

        // Start the new attack coroutine
        attackCoroutine = StartCoroutine(StartAttack());
    }

    public IEnumerator StartAttack()
    {
        while (bulletsSpawned < totalBullets)
        {
            float randomDelay = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomDelay);
            SpawnBullet();
        }

        // Reset the state after the attack is finished
        ResetState();
    }

    void SpawnBullet()
    {
        float randomXPosition = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(randomXPosition, transform.position.y, transform.position.z);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletsSpawned++;
        bulletRb.velocity = Vector2.down * bulletSpeed;

        StartCoroutine(WaitAndStopBullet(bulletRb));
    }

    private IEnumerator WaitAndStopBullet(Rigidbody2D bulletRb)
    {
        float fallDuration = Random.Range(minfallDuration, maxfallDuration);
        yield return new WaitForSeconds(fallDuration); // Wait for the specified fall duration

        bulletRb.velocity = Vector2.zero; // Stop the bullet's movement

        // Capture the bullet variable using a lambda expression
        GameObject capturedBullet = bulletRb.gameObject;

        StartCoroutine(WaitToDestroy(capturedBullet)); // Pass the captured bullet GameObject

        if (bulletsSpawned >= totalBullets)
        {
            StopCoroutine(attackCoroutine); // Stop spawning when totalBullets is reached
        }
    }

    private IEnumerator WaitToDestroy(GameObject bullet)
    {
        yield return new WaitForSeconds(15);
        Destroy(bullet);
    }

    // Reset the state of the script
    private void ResetState()
    {
        bulletsSpawned = 0;
    }
}