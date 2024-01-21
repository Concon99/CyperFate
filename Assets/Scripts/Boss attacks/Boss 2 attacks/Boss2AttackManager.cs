using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2AttackManager : MonoBehaviour
{
    [SerializeField] private BossHealth _BossHealth;
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
            int randomAttack = Random.Range(1, 4);
            print(randomAttack);

            if (randomAttack == 1)
            {
                print("Performing Attack 1");
                
            }
            if (randomAttack == 2)
            {
                print("Performing Attack 2");
               
            }
            if (randomAttack == 3)
            {
                print("Performing Attack 3");
                
            }

            yield return new WaitForSeconds(WaitTime);
        }

        SceneManager.LoadScene(sceneBuildIntext, LoadSceneMode.Single);
        print("ContinuousAttacks ended");
    }
}