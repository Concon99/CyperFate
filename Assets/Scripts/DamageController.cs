using System.Collections;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int EnemyDamage; // Creating damage variable

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

        yield return new WaitForSeconds(1.0f); // Adjust the delay time as needed
    }
}