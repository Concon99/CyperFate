using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int PlayerDamage;
    [SerializeField] private int bHealth = 100;
    [SerializeField] private int bHealthMax = 100;
    [SerializeField] private BossHealthVisual healthbar;

    private Renderer objectRenderer;
    private Color defaultColor;

    void Start() // Corrected method name
    {
        objectRenderer = GetComponent<Renderer>();
        defaultColor = objectRenderer.material.color;
    }

    private void Awake()
    {
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
            BDamage();
        }
        if (collision.CompareTag("Lazer"))
        {
            StartCoroutine(LazerAttack());
        }
    }

    private IEnumerator LazerAttack()
    {
        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(EyeFrame());
            BDamage();
            BDamage();
            BDamage();
            BDamage();
            BDamage();
            yield return new WaitForSeconds(0.1f);
        }
    }

    void BDamage()
    {
        StartCoroutine(EyeFrame());
        print("boss hit~!");
        bHealth -= PlayerDamage;

        healthbar.UpdateHealthBar(bHealth, bHealthMax);

        if (bHealth <= 0)
        {
        }
    }

    void ChangeColor(Color newColor)
    {
        objectRenderer.material.color = newColor;
    }

    IEnumerator EyeFrame()
    {
        ChangeColor(Color.red);
        yield return new WaitForSeconds(0.1f);
        ChangeColor(defaultColor);
    }
}