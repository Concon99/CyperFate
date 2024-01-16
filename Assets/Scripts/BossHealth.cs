using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int PlayerDamage; //creating damage varaible
    [SerializeField] private int bHealth = 100;
    private int f;
    
    private void OnTriggerEnter2D(Collider2D collision) //if impacting something with a 2d collider
    {
        if (collision.CompareTag("Bullet")) //Checking if what its colliding with has the tag "player"
        {
            BDamage();
        }
    }

    void BDamage()
    {
        print("boss hit~!");
        bHealth = bHealth - PlayerDamage; //Taking playerhealth from the HealthController script and then substracting it my damage.
        
        if (bHealth < 0)
        {
            Destroy(gameObject);
        }
        
    }
}