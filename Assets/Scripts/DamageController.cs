using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageController : MonoBehaviour
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

        // You don't need to wait for a second, just update the index.
        yield return null;
    }
}