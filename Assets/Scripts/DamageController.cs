using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int EnemyDamage; //creating damage varaible
    [SerializeField] private HealthController _healthController; //taking health controller script and setting it to _HealthController
    
    private void OnTriggerEnter2D(Collider2D collision) //if impacting something with a 2d collider
    {
        if (collision.CompareTag("Player")) //Checking if what its colliding with has the tag "player"
        {
            Damage();
        }
    }

    void Damage()
    {
        _healthController.PlayerHealth = _healthController.PlayerHealth - EnemyDamage; //Taking playerhealth from the HealthController script and then substracting it my damage.
        _healthController.UpdateHealth(); //Calling the upadtehealth function inside the healthcontroller script so changing the hearts visually.
        //gameObject.SetActive(false); //this deletes the object we can change this
    }
}
