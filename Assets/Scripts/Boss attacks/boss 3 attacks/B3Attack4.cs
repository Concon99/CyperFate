using UnityEngine;
using System.Collections;

public class B3Attack4 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int totalBullets = 15;
    public float bulletSpeed = 5f;
    public float bulletLife = 3f;
    private int bulletsSpawned = 0;

    public AudioSource Vortextsound;

    void Start()
    {
    }

    public void Attack4()
    {
        InvokeRepeating("SpawnBullet", 0f, 1f);
        StartCoroutine(WaitForBulletsToFinish());
    }

    public IEnumerator WaitForBulletsToFinish()
    {
        yield return new WaitUntil(() => bulletsSpawned >= totalBullets);
        // Do something after all bullets are spawned and destroyed
        Debug.Log("All bullets spawned and destroyed");
    }

    void SpawnBullet()
    {
        Vortextsound.Play();
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;
        Destroy(bullet, bulletLife);

        bulletsSpawned++;

        if (bulletsSpawned >= totalBullets)
        {
            CancelInvoke("SpawnBullet");
        }
    }
}