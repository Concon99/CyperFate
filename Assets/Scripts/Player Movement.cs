using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D weaponRB;
    public float speed;
    public Weapon weapon;
    private Animator _animator;

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

        rb.velocity = new Vector2(xAxis,yAxis) * speed;
        
        if (rb.velocity != Vector2.zero) //switching between running and idle animation
        {
            _animator.SetBool("run", true);
        }
        else
        {
            _animator.SetBool("run", false);
        }





        //shooting
        if(Input.GetMouseButtonDown(0))
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

        Vector2 aimDir = mousePos - rb.position;
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;

        weaponRB.rotation = aimAngle;
    }
}
