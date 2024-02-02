using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageControllerBullet : MonoBehaviour
{
    [SerializeField] private int EnemyDamage; // Creating damage variable

    void Start()
    {
        DontDestroyOnLoad(gameObject); // Persist the GameObject between scenes
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(DamageCoroutine());
    }

    private IEnumerator DamageCoroutine()
    {
        HealthController healthController = HealthController.Instance;

        healthController.PlayerHealth -= EnemyDamage;

        healthController.UpdateHealth();

        // Destroy the GameObject this script is attached to
        Destroy(gameObject);

        // You don't need to wait for a second, just update the index.
        yield return null;
    }
}