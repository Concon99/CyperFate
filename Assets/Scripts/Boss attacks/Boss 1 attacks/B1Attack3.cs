using UnityEngine;
using System.Collections;

public class B1Attack3 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletsPerWave = 20;
    public float bulletSpeed = 5f;
    public float bulletLife = 5f;
    public float spawnInterval = 0.2f;
    private int bulletsSpawned = 0;
    private Coroutine attackCoroutine; // Store the reference to the coroutine

    public AudioSource BulletSound;

    void Start()
    {
    }

    public void Attack3()
    {
        Debug.Log("Entering Attack3");

        if (attackCoroutine == null)
        {
            attackCoroutine = StartCoroutine(ContinuousAttack());
        }
    }

    private IEnumerator ContinuousAttack()
    {
        while (bulletsSpawned < bulletsPerWave)
        {
            yield return new WaitForSeconds(spawnInterval);

            SpawnBullet();
        }

        Debug.Log("Exiting Attack3");

        // Reset bulletsSpawned and the coroutine reference
        bulletsSpawned = 0;
        attackCoroutine = null;
    }

    void SpawnBullet()
    {
        BulletSound.Play();
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;

        StartCoroutine(SemiBounceCoroutine(bullet));
        Destroy(bullet, bulletLife);

        bulletsSpawned++;
    }

    private IEnumerator SemiBounceCoroutine(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletLife * 0.2f);

        float randomBounceDirection = Random.Range(-1f, 1f);
        Vector2 bounceVelocity = new Vector2(randomBounceDirection, -1f).normalized * bulletSpeed;

        bullet.GetComponent<Rigidbody2D>().velocity = bounceVelocity;

        yield break;
    }
}