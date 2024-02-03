using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator;
    public Rigidbody2D rb;
    public float speed;
    public Weapon weapon;
    [SerializeField] private HealthController _healthController;

    Vector2 moveDir;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(xAxis, yAxis) * speed;
        if (rb.velocity != Vector2.zero)
        {
            _animator.SetBool("walk", true);
        }
        else
        {
            _animator.SetBool("walk", false);
        }

        // bullet stuff
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("FIRE IN THE HOLE");
            weapon.Fire();
        }

        moveDir = new Vector2(xAxis, yAxis).normalized;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        Debug.Log(speed);

        Vector2 aimDir = mousePos - rb.position;
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = aimAngle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heart"))
        {
            if (_healthController.PlayerHealth < 5)
            {
                _healthController.PlayerHealth += 1;
                _healthController.UpdateHealth();
            }
        }
    }
}