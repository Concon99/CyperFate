using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour
{
    [SerializeField] private int playerDamage = 1; // Use camelCase for variable names
    [SerializeField] private int bHealth = 100;
    [SerializeField] private int bHealthMax = 100;

    private Renderer objectRenderer;
    private Color defaultColor;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        defaultColor = objectRenderer.material.color;
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
            // Use a separate method for the laser damage to improve readability
            ApplyLaserDamage();
        }
    }

    void BDamage()
    {
        StartCoroutine(EyeFrame());
        print("Boss hit~!");
        bHealth -= playerDamage; // Use -= for decrementing

        if (bHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ApplyLaserDamage()
    {
        for (int i = 0; i < 50; i++)
        {
            BDamage(); // Reuse the BDamage method for consistency
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