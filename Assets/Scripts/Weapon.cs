using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public Animator _animator;

    private void Start()
    {
        // Make sure to assign the Animator component here if needed
        // _animator = GetComponent<Animator>();
    }

    public void Fire()
    {
        if (_animator != null)  // Check if _animator is not null to avoid errors
        {
            _animator.SetBool("Shooting", true);  // Trigger the shooting animation
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

            // Consider resetting the shooting animation after a delay
            StartCoroutine(ResetShootingAnimation());
        }
    }

    private IEnumerator ResetShootingAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Shooting", false);  // Reset the shooting animation
    }
}