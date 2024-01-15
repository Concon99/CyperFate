using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife;
    void Start()
    {
        StartCoroutine(BulletFade());
    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    IEnumerator BulletFade()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }
}
