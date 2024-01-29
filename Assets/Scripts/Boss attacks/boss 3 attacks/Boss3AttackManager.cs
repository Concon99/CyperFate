using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss3attackManager : MonoBehaviour
{
    [SerializeField] private BossHealth _BossHealth;
    [SerializeField] private B3Attack1 _B3Attack1;
    [SerializeField] private B3Attack2 _B3Attack2;
    [SerializeField] private B3Attack3 _B3Attack3;
    [SerializeField] private B3Attack4 _B3Attack4;
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
            int randomAttack = Random.Range(1, 5);
            print(randomAttack);

            if (randomAttack == 1)
            {
                print("Performing Attack 1");
                StartCoroutine(_B3Attack1.Attack1());
                
            }
            if (randomAttack == 2)
            {
                print("Performing Attack 2");
               StartCoroutine(_B3Attack2.Attack2());
            }
            if (randomAttack == 3)
            {
                print("Performing Attack 3");
                StartCoroutine(_B3Attack3.Attack3());
            }
            if (randomAttack == 4)
            {
                print("Performing Attack 4");
                _B3Attack4.Attack4();
            }

            yield return new WaitForSeconds(WaitTime);
        }

        SceneManager.LoadScene(sceneBuildIntext, LoadSceneMode.Single);
        print("ContinuousAttacks ended");
    }
}