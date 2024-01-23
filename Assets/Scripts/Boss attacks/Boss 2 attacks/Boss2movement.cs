using System.Collections;
using UnityEngine;

public class Boss2movement : MonoBehaviour
{
    public float EnemySpeed = 2f; // Moderate speed
    [SerializeField] private BossHealth _BossHealth;
    public float MoveDistance = 5f; // Distance to move in each direction
    public float WaitTime = 3f; // Adjusted wait time

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

            // Move down for a specified distance
            GetComponent<Rigidbody2D>().velocity = Vector2.down * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));

            // Move left for a specified distance
            GetComponent<Rigidbody2D>().velocity = Vector2.left * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));

            // Move up for a specified distance
            GetComponent<Rigidbody2D>().velocity = Vector2.up * EnemySpeed;
            yield return new WaitForSeconds(MoveDistance / Mathf.Abs(EnemySpeed));
        }

        // Stop moving when the boss is defeated or some other condition
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}