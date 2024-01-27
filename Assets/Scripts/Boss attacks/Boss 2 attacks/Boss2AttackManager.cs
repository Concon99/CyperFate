using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2AttackManager : MonoBehaviour
{
    [SerializeField] private BossHealth _BossHealth;
    [SerializeField] private EnemyBulletSpawner _EnemyBulletSpawner;
    public float WaitTime = 5f;
    public float TimeBeforeAttacks;
    public int sceneBuildIndex; // Corrected variable name

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
            int randomAttack = Random.Range(1, 4); // Corrected range

            print(randomAttack);

            if (randomAttack == 1)
            {
                print("Performing Attack 1");
                _EnemyBulletSpawner.Attack1();
            }
            else if (randomAttack == 2)
            {
                print("Performing Attack 2");
                // Add code for Attack 2
            }
            else if (randomAttack == 3)
            {
                print("Performing Attack 3");
                // Add code for Attack 3
            }
            else if (randomAttack == 4)
            {
                print("Performing Attack 4");
                // Add code for Attack 4
            }

            yield return new WaitForSeconds(WaitTime);
        }

        print("ContinuousAttacks ended");
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}