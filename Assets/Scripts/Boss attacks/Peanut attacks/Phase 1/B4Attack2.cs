using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4Attack2 : MonoBehaviour
{
    public GameObject Portalprefab;
    private Transform playerTransform;
    
    
    void Start()
    {

    }

    
    // Start is called before the first frame update
    public void Attack2()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject Portal = Instantiate(Portalprefab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}