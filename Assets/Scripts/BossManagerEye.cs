using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManagerEye : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bossHealth = 200;
    public float bossDice = 1;
    public float fireForce = 20f;

    public float attackOneBulletCooldown;
    public bool attackOneCooldown = false;

    public Transform firePointAttackOne;

    public Rigidbody2D bossBulletRB;
    public Rigidbody2D playerRB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackOneBulletCooldown = Random.Range(0.5f, 1.1f);

        Vector2 aimDir = bossBulletRB.position - playerRB.position;
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;

        bossBulletRB.rotation = aimAngle;

        if(bossDice == 1 && attackOneCooldown == false)
        {
            StartCoroutine(AttackOne());
            attackOneCooldown = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>())
        {
            bossHealth = bossHealth - PlayerMovement.damage;
        }        
    }

    IEnumerator AttackOne()
    {
        yield return new WaitForSeconds(attackOneBulletCooldown);
        for (int i = 0; i < 5; i++)
        {
            GameObject attackOneGO = Instantiate(bulletPrefab, firePointAttackOne.position, firePointAttackOne.rotation);
            attackOneGO.GetComponent<Rigidbody2D>().AddForce(-firePointAttackOne.up * fireForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(attackOneBulletCooldown);
        }
        yield return new WaitForSeconds(1f);
        attackOneCooldown = false;
    }
}
