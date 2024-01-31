using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4Attack2_4 : MonoBehaviour
{
    public GameObject TurretPreFab;
    private Transform playerTransform;
    
    
    void Start()
    {
    }

    
    // Start is called before the first frame update
    public void Attack2()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject turret = Instantiate(TurretPreFab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }


}