using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject HeartPreFab;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HeartSpawning());
    }

    public IEnumerator HeartSpawning()
    {
        while (true)
        {
        CreateHeart();
        float WaitTime = Random.Range(10,20);
        yield return new WaitForSeconds(WaitTime);
        }
    }
    


    public void CreateHeart()
    {
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(HeartPreFab, spawnPosition, Quaternion.identity);
        }
    }
}
