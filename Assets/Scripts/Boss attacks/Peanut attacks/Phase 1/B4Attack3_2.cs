using System.Collections;
using UnityEngine;

public class B4Attack3_2 : MonoBehaviour
{
    private Transform playerTransform;
    public GameObject Bulletprefab1;
    public GameObject Bulletprefab2;
    public GameObject Bulletprefab3;
    public GameObject Bulletprefab4;
    public GameObject Bulletprefab5;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, -directionToPlayer * 2);
        transform.rotation = targetRotation * Quaternion.Euler(0, 0, 90);
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            Vector3 spawnPosition1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 spawnPosition2 = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);
            Vector3 spawnPosition3 = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
            Vector3 spawnPosition4 = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            Vector3 spawnPosition5 = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);

            yield return new WaitForSeconds(3);

            for (int i = 0; i < 5; i++)
            {
                GameObject Bullet1 = Instantiate(Bulletprefab1, spawnPosition1, Quaternion.identity);
                GameObject Bullet2 = Instantiate(Bulletprefab2, spawnPosition2, Quaternion.identity);
                GameObject Bullet3 = Instantiate(Bulletprefab3, spawnPosition3, Quaternion.identity);
                GameObject Bullet4 = Instantiate(Bulletprefab4, spawnPosition4, Quaternion.identity);
                GameObject Bullet5 = Instantiate(Bulletprefab5, spawnPosition5, Quaternion.identity);

                yield return new WaitForSeconds(0.5f);
            }
            Destroy(gameObject);

            // No delay between bullet spawns

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic goes here
    }

    public void Phase2()
    {
        Destroy(gameObject);
    }
}