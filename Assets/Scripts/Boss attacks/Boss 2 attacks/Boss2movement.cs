using System.Collections;
using UnityEngine;

public class Boss2movement : MonoBehaviour
{
    public float EnemySpeed = 2f; // Moderate speed
    [SerializeField] private BossHealth _BossHealth;
    public float MoveDistance = 5f; // Distance to move in each direction
    public float WaitTime = 3f; // Adjusted wait time
    public bool Stopmoving = false;
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
        StartCoroutine(MoveBossInBox());
    }

    void Update()
    {
        // You can add any other logic here if needed
    }

    IEnumerator MoveBossInBox()
    {
        while (_BossHealth.BHealth > 0f)
        {
            // Move right for a specified distance
            GetComponent<Rigidbody2D>().velocity = Vector2.right * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));
            if (Stopmoving == true)
            {
                break;
                Attack4();
            }
            // Move down for a specified distance
            GetComponent<Rigidbody2D>().velocity = Vector2.down * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));
            if (Stopmoving == true)
            {
                break;
                Attack4();
            }
            // Move left for a specified distance
            GetComponent<Rigidbody2D>().velocity = Vector2.left * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));
            if (Stopmoving == true)
            {
                break;
                Attack4();
            }
            // Move up for a specified distance
            GetComponent<Rigidbody2D>().velocity = Vector2.up * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));
            if (Stopmoving == true)
            {
                break;
                Attack4();
            }
        }

        // Stop moving when the boss is defeated or some other condition
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }


    public void Attack4()
    {
        StartCoroutine(SpawnBulletsWithDelay());
    }

    private IEnumerator SpawnBulletsWithDelay()
{
    float fixedDelay = 0.1f;

    for (int i = 0; i < totalBullets; i++)
    {
        SpawnHomingBullet();
        yield return new WaitForSeconds(fixedDelay);
    }

    Stopmoving = false;
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
            Stopmoving = false;
        }
    }
}