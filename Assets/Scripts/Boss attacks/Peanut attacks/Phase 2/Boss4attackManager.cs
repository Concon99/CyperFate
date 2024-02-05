using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss4attackManager : MonoBehaviour
{
    [SerializeField] private Phase2BossHealth _phase2BossHealth_;
   
    public float WaitTime = 5f;
    public float TimeBeforeAttacks;
    public int sceneBuildIntext;
    public Renderer objectRenderer;
    [SerializeField] private int bHealth = 100;
    [SerializeField] private int bHealthMax = 100;
    [SerializeField] private B1Attack1 _B1Attack1;
    [SerializeField] private B1Attack2 _B1Attack2;
    [SerializeField] private B1Attack3 _B1Attack3;
    [SerializeField] private EnemyBulletSpawner _EnemyBulletSpawner;
    [SerializeField] private B5Attack4 _B5Attack4;
    [SerializeField] private B5Attack4_2 _B5Attack4_2;
    [SerializeField] private B5Attack5 _B5Attack5;
    [SerializeField] private B5Attack5_2 _B5Attack5_2;
    [SerializeField] private B3Attack3 _B3Attack3;

    [SerializeField] private BossHealthVisual healthbar;



    private void Start()
    {
        healthbar = GetComponentInChildren<BossHealthVisual>();
        // Ensure the renderer is initially visible
        objectRenderer.enabled = false;
    }

    public void Phase2()
    {
        healthbar.UpdateHealthBar(bHealth, bHealthMax);
        StartCoroutine(ContinuousAttacks());
    }

    private IEnumerator ContinuousAttacks()
    {
        objectRenderer.enabled = true;
        print("ContinuousAttacks started");
        healthbar.UpdateHealthBar(bHealth, bHealthMax);
        yield return new WaitForSeconds(TimeBeforeAttacks);

        while (_phase2BossHealth_.BHealth > 0f)
        {
            print("New attack");
            int randomAttack = Random.Range(1, 6);
            print(randomAttack);

            if (randomAttack == 1)
            {
                print("Performing Attack 1");
                _B1Attack1.Attack1();
                _B1Attack2.Attack2();
            }
            if (randomAttack == 2)
            {
                print("Performing Attack 2");
                _B1Attack3.Attack3();
            }
            if (randomAttack == 3)
            {
                print("Performing Attack 3");
                _EnemyBulletSpawner.Attack1();
            }
            if (randomAttack == 4)
            {
                print("Performing Attack 4");
                _B5Attack4.Attack4();
                _B5Attack4_2.Attack4();
            }

            if (randomAttack == 5)
            {
                print("Performing Attack 5");
                _B5Attack5.Attack5();
                _B5Attack5_2.Attack5();
            }

            if (randomAttack == 6)
            {
                print("Performing Attack 6");
                _B3Attack3.Attack3();
            }


            // Toggle visibility

            yield return new WaitForSeconds(WaitTime);
        }

        SceneManager.LoadScene(sceneBuildIntext, LoadSceneMode.Single);
        print("ContinuousAttacks ended");
    }

    void Update()
    {
    
        if (_phase2BossHealth_.BHealth < 0f)
        {
            Debug.Log("Switching scenes");
            SceneManager.LoadScene(sceneBuildIntext, LoadSceneMode.Single);
        }
    }
}
