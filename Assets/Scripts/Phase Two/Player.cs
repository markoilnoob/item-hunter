using System;
using UnityEngine;

public class Player : Character
{
    private bool IsGrounded;
    private float walkSpeed = 3f;
    private float maxSpeed = 8f;
    private float jumpForce = 2f;
    public Action OnPerformedAction;

    private void Update()
    {
        Movement();
        Jump();
        PerformAction();
    }

    protected override void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        AddForce(Vector2.right, walkSpeed, horizontal);

        //clamp velocity
        rigidbody2d.linearVelocityX = Mathf.Clamp(rigidbody2d.linearVelocityX, -maxSpeed, maxSpeed);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            AddForce(Vector2.up, jumpForce, 1, ForceMode2D.Impulse);
            IsGrounded = false;
        }
    }

    protected override void PerformAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnPerformedAction?.Invoke();
        }
    }

    public void AddForce(Vector2 direction, float force, float axis = 1, ForceMode2D forceMode2D = ForceMode2D.Force)
    {
        rigidbody2d.AddForce(direction * (axis * force), forceMode2D);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Vector2.Dot(other.contacts[0].normal, Vector2.up) > 0.5f)
        {
            IsGrounded = true;
        }
    }
}
