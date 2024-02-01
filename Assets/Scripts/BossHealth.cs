using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int PlayerDamage;
    [SerializeField] private int bHealth = 100;
    [SerializeField] private int bHealthMax = 100;
    [SerializeField] private BossHealthVisual healthbar; // Corrected variable name

    private void Awake() // Corrected method name
    {
        // Assuming you have a Rigidbody2D component on the same GameObject
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Assuming BossHealthVisual is a component in the children of this GameObject
        healthbar = GetComponentInChildren<BossHealthVisual>();
    }

    public int BHealth // Property to access bHealth
    {
        get { return bHealth; }
        set { bHealth = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            BDamage();
        }
        if (collision.CompareTag("Lazer")) //laser damage 
        {
            StartCoroutine(LazerAttack());
        }
    }

    private IEnumerator LazerAttack()
    {
        for (int i = 0; i < 10; i++)
        {
            BDamage();
            BDamage();
            BDamage();
            BDamage();
            BDamage();
            yield return new WaitForSeconds(0.1f); // Fixed the typo here
        }
    }

    void BDamage()
    {
        print("boss hit~!");
        bHealth = bHealth - PlayerDamage;

        // Assuming healthbar has a method like UpdateHealthBar that takes parameters
        healthbar.UpdateHealthBar(bHealth, bHealthMax);

        if (bHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}