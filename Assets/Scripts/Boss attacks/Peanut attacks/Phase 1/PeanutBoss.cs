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

    private Renderer objectRenderer;
    private Color defaultColor;

    public AudioSource _Static;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        defaultColor = objectRenderer.material.color;
    }
    
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
            StartCoroutine(EyeFrame());
            StartCoroutine(BDamage());
        }
    }

    IEnumerator BDamage()
    {
        print("boss hit~!");
        bHealth = bHealth - PlayerDamage;

        // Assuming healthbar has a method like UpdateHealthBar that takes parameters
        healthbar.UpdateHealthBar(bHealth, bHealthMax);

        if (bHealth <= 150)
        {
            Debug.Log("End");

            _HealthController.PlayerHealth = 100;
            canvasGroup.alpha = 1f;
            _Static.Play();
            yield return new WaitForSeconds(3);


            canvasGroup.alpha = 0f;
            _HealthController.PlayerHealth = 5;
            _Boss4attackManager.Phase2();
            healthbar.UpdateHealthBar(bHealth, bHealthMax);
            canvasGroup.alpha = 0f;
            Destroy(gameObject);
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
    public void Phase2()
    {
    }
}