using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private float activeMoveSpeed;
    public float dashSpeed;
    public PlayerMovement playerMovement;

    public float dashLength = 0.5f, dashCooldown = 1f;

    private float dashCounter;
    private bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = playerMovement.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.X)) && !isDashing)
        {
            StartCoroutine(DashRoutine());
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                playerMovement.speed = activeMoveSpeed;
                isDashing = false;
            }
        }
    }

    IEnumerator DashRoutine()
    {
        isDashing = true;

        playerMovement.speed = dashSpeed;
        dashCounter = dashLength;

        // Wait for the dash to finish
        yield return new WaitForSeconds(dashLength);

        // Apply cooldown after each dash
        yield return new WaitForSeconds(dashCooldown);

        playerMovement.speed = activeMoveSpeed;
        isDashing = false;
    }
}