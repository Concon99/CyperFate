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
    public CanvasGroup canvasGroup;





    //ALL THE SCRIPTS I NEED TO CALL WHEN KILLING BOSS
    [SerializeField] private B4Attack1 _B4Attack1;
    [SerializeField] private B4Attack1_2 _B4Attack1_2;
    [SerializeField] private B4Attack2 _B4Attack2;
    [SerializeField] private B4Attack2_2 _B4Attack2_2;
    [SerializeField] private B4Attack2_4 _B4Attack2_4;
    [SerializeField] private B4Attack2_3 _B4Attack2_3;
    [SerializeField] private B4Attack3 _B4Attack3;
    [SerializeField] private B4Attack3_3 _B4Attack3_3;
    [SerializeField] private B4Attack4 _B4Attack4;



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

            _HealthController.PlayerHealth = 5;
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(2);

            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha += 0.1f;
                yield return new WaitForSeconds(0.2f);
            }
            _B4Attack1.Phase2();
            _B4Attack1_2.Phase2();
            _B4Attack2.Phase2();
            _B4Attack2_2.Phase2();
            _B4Attack2_4.Phase2();
            _B4Attack2_3.Phase2();
            _B4Attack3.Phase2();
            _B4Attack3_3.Phase2();
            _B4Attack4.Phase2();

            Destroy(gameObject);
        }
    }


    public void Phase2()
    {

    }
}