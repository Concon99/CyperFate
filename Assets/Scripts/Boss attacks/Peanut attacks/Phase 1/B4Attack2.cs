using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4Attack2 : MonoBehaviour
{
    public GameObject TurretPreFab;
    // Start is called before the first frame update
    void Start()
    {
    }


    public void Attack2()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject turret = Instantiate(TurretPreFab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Phase2()
    {
        Destroy(gameObject);
    }
}
