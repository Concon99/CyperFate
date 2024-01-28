using System.Collections;
using UnityEngine;

public class B2Attack3 : MonoBehaviour
{
    [SerializeField] private B2Attack1 _B2Attack1;
    [SerializeField] private B2Attack4 _B2Attack4;
    public Animator transation;


    public void Attack3()
    {
            transation.SetBool("playershow", true);
            _B2Attack1.speed += 2f;
            _B2Attack4.speed += 2f;
            StartCoroutine(WaitForAnimationCooldown());
    }

    private IEnumerator WaitForAnimationCooldown()
    {

        // Wait for 0.5 seconds
        yield return new WaitForSeconds(1f);
        transation.SetBool("playershow", false);


    }
}