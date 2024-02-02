using System.Collections;
using UnityEngine;

public class B2Attack2 : MonoBehaviour
{
    [SerializeField] private Boss2movement _Boss2movement;
    public Animator transation;



    public void Attack2()
    {
            transation.SetBool("Speedup", true);
            _Boss2movement.EnemySpeed += 5;
            StartCoroutine(WaitForAnimationCooldown());
    }

    private IEnumerator WaitForAnimationCooldown()
    {
        // Wait for 0.5 seconds
        yield return new WaitForSeconds(1f);
        transation.SetBool("Speedup", false);
    }
}