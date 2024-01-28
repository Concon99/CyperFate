using System.Collections;
using UnityEngine;

public class Boss2movement : MonoBehaviour
{
    public float EnemySpeed = 2f;
    [SerializeField] private BossHealth _BossHealth;
    public float MoveDistance = 5f;
    public float WaitTime = 3f;
    private Vector2 moveDirection;
    private bool isAttacking = false;
    public GameObject bulletPrefab;
    public int totalBullets = 15;
    public float bulletLife = 3f;
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
            MoveBoss();

            moveDirection = GetCurrentDirection();

            // isAttacking = true; // Removed this line

            yield return new WaitUntil(() => isAttacking); // Wait until isAttacking is true

            isAttacking = false;
        }

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void MoveBoss()
    {
        if (!isAttacking)
        {
            GetComponent<Rigidbody2D>().velocity = moveDirection * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));
        }
    }

    Vector2 GetCurrentDirection()
    {
        Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;

        if (currentVelocity == Vector2.right)
        {
            return Vector2.right;
        }
        else if (currentVelocity == Vector2.down)
        {
            return Vector2.down;
        }
        else if (currentVelocity == Vector2.left)
        {
            return Vector2.left;
        }
        else if (currentVelocity == Vector2.up)
        {
            return Vector2.up;
        }

        return Vector2.right;
    }

    public void TriggerAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Attack4();
        }
    }

    public void Attack4()
    {
        if (bulletsSpawned < totalBullets)
        {
            float fixedDelay = 0.1f;
            StartCoroutine(SpawnBulletsWithDelay(fixedDelay));
        }
    }

    private IEnumerator SpawnBulletsWithDelay(float delay)
    {
        for (int i = 0; i < totalBullets; i++)
        {
            SpawnHomingBullet();
            yield return new WaitForSeconds(delay);
        }

        // Stopmoving = false; // Removed this line
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
            // Stopmoving == false; // Removed this line
        }
    }
}