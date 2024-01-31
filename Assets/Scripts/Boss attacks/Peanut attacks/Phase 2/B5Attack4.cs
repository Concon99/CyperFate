using System.Collections;
using UnityEngine;

public class B5Attack4 : MonoBehaviour
{
    private Transform playerTransform;
    public float rotationSpeed = 5f;
    public float rotationTime = 5f;
    public GameObject TinyBulletPreFab;
    public int initialBullets = 5;
    public Renderer objectRenderer;

    private int Bulletsleft;

    // Rename this method to something like StartAttack1 to avoid confusion
    public void Attack4()
    {
        objectRenderer.enabled = false;
        Bulletsleft = initialBullets;
        StartCoroutine(Attack1Coroutine());
    }

    private IEnumerator Attack1Coroutine()
    {
        objectRenderer.enabled = true;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(TinyBullets());
        float elapsedTime = 0f;

        while (elapsedTime < rotationTime)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, -directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.identity;
        Bulletsleft = initialBullets;
    }

    private IEnumerator TinyBullets()
    {
        while (Bulletsleft > 0)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject TinyBullet = Instantiate(TinyBulletPreFab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Bulletsleft--;
        }
    }
}