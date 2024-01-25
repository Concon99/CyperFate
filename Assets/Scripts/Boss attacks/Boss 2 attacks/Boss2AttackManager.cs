using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2AttackManager : MonoBehaviour
{
    [SerializeField] private BossHealth _BossHealth;
    [SerializeField] private B2Attack1 _B2Attack1;
    public float WaitTime = 5f;
    public float TimeBeforeAttacks;
    public int sceneBuildIntext;

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
                _B2Attack1.B2Attack1Function();
            }
            if (randomAttack == 2)
            {
                print("Performing Attack 2");
            }
            if (randomAttack == 3)
            {
                print("Performing Attack 3");
            }
            if (randomAttack == 4)
            {
                print("Performing Attack 4");
            }
             if (randomAttack == 5)
            {
                print("Performing Attack 5");
            }

            yield return new WaitForSeconds(WaitTime);
        }

        print("ContinuousAttacks ended");
        SceneManager.LoadScene(sceneBuildIntext, LoadSceneMode.Single);
    }
}