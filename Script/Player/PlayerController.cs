using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isMoving;
    private float inputRaw;
    public PlayerData playerData;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        Move(inputRaw);
    }

    void CheckInput()
    {
        inputRaw = Input.GetAxisRaw("Horizontal");
    }

    void Move(float dir)
    {
        if (Mathf.Abs(dir) > 0)
            isMoving = true;
        else if (dir == 0)
            isMoving = false;
        
        rb.velocity = new Vector2(dir * playerData.moveSpeed, rb.velocity.y);
    }
}
