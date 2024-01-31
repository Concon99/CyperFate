using System.Collections;
using UnityEngine;

public class B4Attack3 : MonoBehaviour
{
    public GameObject Portalprefab;
    private GameObject portalInstance; // Variable to store the instantiated portal

    void Start()
    {
    }

    // Start is called before the first frame update
    public void Attack3()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        portalInstance = Instantiate(Portalprefab, spawnPosition, Quaternion.identity);
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