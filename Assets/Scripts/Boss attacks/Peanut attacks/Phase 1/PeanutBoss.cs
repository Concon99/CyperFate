using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PeanutBoss : MonoBehaviour
{
    [SerializeField] private int PlayerDamage;
    [SerializeField] private int bHealth = 100;
    [SerializeField] private int bHealthMax = 100;
    [SerializeField] private BossHealthVisual healthbar;
    [SerializeField] private HealthController _HealthController;
    [SerializeField] private Boss4attackManager _Boss4attackManager;
    public CanvasGroup canvasGroup;

    private void Awake()
    {
        // Assuming you have a Rigidbody2D component on the same GameObject
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Assuming BossHealthVisual is a component in the children of this GameObject
        healthbar = GetComponentInChildren<BossHealthVisual>();
    }

    public int BHealth
    {
        get { return bHealth; }
        set { bHealth = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            StartCoroutine(BDamage());
        }
        if (collision.CompareTag("Lazer"))
        {
            for (int i = 0; i < 50; i++)
            {
                StartCoroutine(BDamage());
            }
        }
    }

    IEnumerator BDamage()
    {
        print("boss hit~!");
        bHealth = bHealth - PlayerDamage;

        // Assuming healthbar has a method like UpdateHealthBar that takes parameters
        healthbar.UpdateHealthBar(bHealth, bHealthMax);

        if (bHealth <= 0)
        {
            Debug.Log("End");

            _HealthController.PlayerHealth = 100;
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(2);

            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha += 0.1f;
                yield return new WaitForSeconds(0.2f);
            }
            _HealthController.PlayerHealth = 5;
            _Boss4attackManager.Phase2();
            healthbar.UpdateHealthBar(bHealth, bHealthMax);
            Destroy(gameObject);
        }
    }

    public void Phase2()
    {
        // Implement phase 2 logic here if needed
    }
}