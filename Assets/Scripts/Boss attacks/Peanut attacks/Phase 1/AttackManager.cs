using System.Collections;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public Transform player;
    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;
    public bool Attacking;

    [SerializeField] private BossHealth _BossHealth;
    [SerializeField] private B4Attack1 _B4Attack1;
    [SerializeField] private B4Attack1_2 _B4Attack1_2;
    [SerializeField] private B4Attack2 _B4Attack2;
    [SerializeField] private B4Attack2_4 _B4Attack2_4;
    [SerializeField] private B4Attack3 _B4Attack3;


    // Start is called before the first frame update
    void Start()
    {
        Attacking = false;
        StartCoroutine(Movement());
        StartCoroutine(FightStart());
    }

    IEnumerator Movement()
    {
        while (_BossHealth.BHealth > 0)
        {
            transform.position = spawner1.position;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            while (!Attacking)
            {
                Debug.Log("waiting...");
                yield return null;
            }

            yield return new WaitForSeconds(1.5f);

            transform.position = spawner2.position;
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);

            while (!Attacking)
            {
                Debug.Log("waiting...");
                yield return null;
            }

            yield return new WaitForSeconds(1.5f);

            transform.position = spawner3.position;
            transform.rotation = Quaternion.Euler(0f, 0f, -180f);

            while (!Attacking)
            {
                Debug.Log("waiting...");
                yield return null;
            }

            yield return new WaitForSeconds(1.5f);

            transform.position = spawner4.position;
            transform.rotation = Quaternion.Euler(0f, 0f, -270f);
            
            while (!Attacking)
            {
                Debug.Log("waiting...");
                yield return null;
            }

            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator FightStart()
    {
        while (_BossHealth.BHealth > 0)
        {
            int WaitTime = Random.Range(3,8);
            yield return new WaitForSeconds(WaitTime);

                int randomAttack = Random.Range(1, 4);
                
                if (randomAttack == 1)
                {
                    Debug.Log("Attack 1");
                    Attacking = true;
                    _B4Attack1.Attack1();
                    _B4Attack1_2.Attack1();
                    yield return new WaitForSeconds(5);
                    Attacking = false;
                    
                }

                if (randomAttack == 2)
                {
                    Debug.Log("Attack 2");
                    Attacking = true;
                    _B4Attack2.Attack2();
                    _B4Attack2_4.Attack2();
                    yield return new WaitForSeconds(10);
                    Attacking = false;
                }

                if (randomAttack == 3)
                {
                    Debug.Log("Attack 3");
                    Attacking = true;
                    _B4Attack3.Attack3();
                    yield return new WaitForSeconds(5);
                    Attacking = false;
                }

                if (randomAttack == 4)
                {
                    Debug.Log("Attack 4");
                    Attacking = true;
                    yield return new WaitForSeconds(3);
                    Attacking = false;
                }

                yield return null;
        }

            yield return null;  // Adjust the yield statement as needed
    }
} 
