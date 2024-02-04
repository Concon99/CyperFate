using System.Collections;
using UnityEngine;

public class DamageControllerBullet : MonoBehaviour
{
    [SerializeField] private int EnemyDamage; // Creating damage variable
    private AudioSource Hurt;

    void Start()
    {
        // Load the audio clip dynamically from the Resources folder
        AudioClip hurtClip = Resources.Load<AudioClip>("HurtAudioClip");

        // Create an AudioSource component dynamically
        Hurt = gameObject.AddComponent<AudioSource>();
        Hurt.clip = hurtClip;
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

        if (Hurt != null && Hurt.clip != null)
            Hurt.Play();

        healthController.UpdateHealth();

        // Destroy the GameObject this script is attached to
        Destroy(gameObject);

        // You don't need to wait for a second, just update the index.
        yield return null;
    }
}