using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbDamage : MonoBehaviour
{
    [SerializeField] private int EnemyDamage; // Creating damage variable

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Access the HealthController instance using the singleton pattern
            HealthController healthController = HealthController.Instance;
            
            // Damage the player
            healthController.PlayerHealth -= EnemyDamage;

            // Call the UpdateHealth function inside the HealthController script to update the visual representation of health
            healthController.UpdateHealth();
        }
    }
}