using System.Collections;
using UnityEngine;

public class RobotEyes : MonoBehaviour
{
    private float _nextShot = 0.15f;
    [SerializeField] private float _fireDelay = 0.5f;
    public GameObject Lazer;
    public Transform firePoint;
    public float charge;
    public float chargemax;
    [SerializeField] private EyeCharge _EyeCharge;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FireLazer());
        }
    }

    private IEnumerator FireLazer()
    {
        if (!(charge < chargemax))
        {
            print("FORED");
            GameObject clone = Instantiate(Lazer, firePoint.position, firePoint.rotation);

			charge = 0f;
			_EyeCharge.UpdateChargeBar(charge, chargemax);
			CalculateNextShotTime();
			
            yield return new WaitForSeconds(2f); // Wait for 2 seconds after bullet is destroyed
            Destroy(clone);
        }
    }

    private void CalculateNextShotTime()
    {
        StartCoroutine(ChargeAndShow());
    }

    private IEnumerator ChargeAndShow()
    {
        while (charge < chargemax)
        {
            charge += 0.1f;
            _EyeCharge.UpdateChargeBar(charge, chargemax);
            yield return new WaitForSeconds(0.1f);
        }
    }
}