using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RobotEyes : MonoBehaviour
{
   private float _nextShot = 0.15f;
	[SerializeField] 
	private float _fireDelay = 0.5f;
	public GameObject Lazer;
	public Transform firePoint;
	

 // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextShot)
		{
			print("FORED");
			GameObject clone = Instantiate(Lazer, firePoint.position, firePoint.rotation);
			_nextShot = Time.time + _fireDelay;
			Destroy(clone, 2f);
		}
		

    }
}
