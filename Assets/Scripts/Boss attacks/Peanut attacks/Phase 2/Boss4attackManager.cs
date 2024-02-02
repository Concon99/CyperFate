using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss4attackManager : MonoBehaviour
{
    [SerializeField] private BossHealth _BossHealth;
   
    public float WaitTime = 5f;
    public float TimeBeforeAttacks;
    public int sceneBuildIntext;
    public Renderer objectRenderer;

    [SerializeField] private B1Attack1 _B1Attack1;
    [SerializeField] private B1Attack2 _B1Attack2;
    [SerializeField] private B1Attack3 _B1Attack3;
    [SerializeField] private EnemyBulletSpawner _EnemyBulletSpawner;
    [SerializeField] private B5Attack4 _B5Attack4;
    [SerializeField] private B5Attack4_2 _B5Attack4_2;
    [SerializeField] private B5Attack5 _B5Attack5;
    [SerializeField] private B5Attack5_2 _B5Attack5_2;
    [SerializeField] private B3Attack3 _B3Attack3;

    private void Start()
    {
        // Ensure the renderer is initially visible
        objectRenderer.enabled = false;
    }

    public void Phase2()
    {
        
        _BossHealth.BHealth = 350;
        StartCoroutine(ContinuousAttacks());
    }

    private IEnumerator ContinuousAttacks()
    {
        objectRenderer.enabled = true;
        print("ContinuousAttacks started");
        yield return new WaitForSeconds(TimeBeforeAttacks);

        while (_BossHealth.BHealth > 0f)
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
    
        if (_BossHealth.BHealth < 0f)
        {
            Debug.Log("Switching scenes");
            SceneManager.LoadScene(sceneBuildIntext, LoadSceneMode.Single);
        }
    }
}
