using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4Attack3 : MonoBehaviour
{
    public GameObject TurretPreFab;
    // Start is called before the first frame update
    void Start()
    {
        Attack3();
    }


    public void Attack3()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject turret = Instantiate(TurretPreFab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
