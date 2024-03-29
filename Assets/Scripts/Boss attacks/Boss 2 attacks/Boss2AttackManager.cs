using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2AttackManager : MonoBehaviour
{
    [SerializeField] private BossHealth _BossHealth;
    [SerializeField] private EnemyBulletSpawner _EnemyBulletSpawner;
    [SerializeField] private B2Attack2 _B2Attack2;
    [SerializeField] private HealthController _healthController;
    [SerializeField] private Boss2movement _Boss2movement;
    public float WaitTime = 5f;
    public float TimeBeforeAttacks;
    public int sceneBuildIndex;

    private void Start()
    {
        StartCoroutine(ContinuousAttacks());
    }

    private IEnumerator ContinuousAttacks()
    {
        print("ContinuousAttacks started");
        yield return new WaitForSeconds(TimeBeforeAttacks);

        while (_BossHealth.BHealth > 0f)
        {
            print("New attack");
            int randomAttack = Random.Range(1, 4);

            print(randomAttack);

            if (randomAttack == 1)
            {
                print("Performing Attack 1");
                // No need to call _EnemyBulletSpawner.Attack1() here
            }
            else if (randomAttack == 2)
            {
                print("Performing Attack 2");
                _B2Attack2.Attack2();  // Keep this line if Attack2() method exists
            }

            yield return new WaitForSeconds(WaitTime);
        }

        print("ContinuousAttacks ended");
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    void Update()
    {
        _healthController.UpdateHealth();
    }
}