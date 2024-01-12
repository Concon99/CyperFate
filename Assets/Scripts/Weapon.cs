using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D playerRB;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    void Update()
    {
        rb.position = playerRB.position;
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
