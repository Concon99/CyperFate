using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int PlayerDamage;
    [SerializeField] private int bHealth = 100;

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
    }

    void BDamage()
    {
        print("boss hit~!");
        bHealth = bHealth - PlayerDamage;

        if (bHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}