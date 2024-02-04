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
    private int bulletsSpawned = 0;
    public float randomDelay;
    private Rigidbody2D rb;

    public Vector2 TargetPosition = new Vector2(0f, 0f); // Specify the desired destination coordinates

    public Animator _phases;

    void Start()
    {
        _phases = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
            _phases.SetInteger("phase", 1);
            rb.velocity = Vector2.right * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));


            // Move down for a specified distance
            _phases.SetInteger("phase", 2);
            rb.velocity = Vector2.down * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));

            // Move left for a specified distance
            _phases.SetInteger("phase", 3);
            rb.velocity = Vector2.left * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));

            // Move up for a specified distance
            _phases.SetInteger("phase", 4);
            rb.velocity = Vector2.up * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));
        }
    }



    private IEnumerator SpawnBulletsWithDelay(float delay)
    {
        for (int i = 0; i < totalBullets; i++)
        {
            SpawnHomingBullet();
            yield return new WaitForSeconds(delay);
        }

        Stopmoving = true;  // Set the flag to stop moving
        rb.isKinematic = false;  // Disable physics for collisions during bullet attack
        yield return new WaitUntil(() => bulletsSpawned >= totalBullets);
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
            StartCoroutine(MoveBossInBox());
        }
    }
}