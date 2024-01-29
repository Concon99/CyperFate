using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
	private float activeMoveSpeed;
	public float dashSpeed;
	public PlayerMovement playerMovement;

	public float dashLength = 0.5f, dashCooldown = 1f;

	private float dashCounter;

	private float dashCoolCounter;

	// Start is called before the first frame update
	void Start()
	{
		activeMoveSpeed = playerMovement.speed;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			print("dashed");
			if (dashCoolCounter <= 0 && dashCounter <= 0)
			{
				activeMoveSpeed = dashSpeed;
				dashCounter = dashLength;
			}
		}

		if (dashCounter > 0)
		{
			dashCounter -= Time.deltaTime;

			if (dashCounter <= 0)
			{
				activeMoveSpeed = playerMovement.speed;
				dashCoolCounter = dashCooldown;

				if (dashCoolCounter > 0)
				{
					dashCoolCounter -= Time.deltaTime;
				}
			}
		}
	}
}