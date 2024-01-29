using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    [SerializeField] private int PlayerDamage;
    [SerializeField] private int bHealth = 100;
    [SerializeField] private int bHealthMax = 100;

    private void Awake() // Corrected method name
    {
        // Assuming you have a Rigidbody2D component on the same GameObject
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
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
            for(int i = 0; i < 50; i++)
            {
                BDamage();
            }
            
        }
    }

    void BDamage()
    {
        print("boss hit~!");
        bHealth = bHealth - PlayerDamage;

        if (bHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}