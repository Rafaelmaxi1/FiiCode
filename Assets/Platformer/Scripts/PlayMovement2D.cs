using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement2D : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private float speed = 8f;
    //private float velocity = 0;
    private float jumpingPower = 14f;
    private float forceFieldCooldown = 0f;
    private bool isFacingRight = true;

    private bool isDashing = false;
    private bool canDash = true;
    private float dashPower = 30f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask bulletLayer;
    [SerializeField] private TrailRenderer trail;


    private void Update()
    {
        forceFieldCooldown += Time.deltaTime;

        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        if (hitByBullet())
        {
            Debug.Log("Hit");
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = new Vector2(horizontal * dashPower, 0f);
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private bool hitByBullet()
    {
        return Physics2D.OverlapCircle(transform.position, 0.5f, bulletLayer);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        trail.emitting = true;

        rb.gravityScale = 0f;
        rb.velocity = new Vector2(horizontal * dashPower, 0f);

        yield return new WaitForSeconds(0.2f);

        trail.emitting = false;

        rb.gravityScale = 3f;
        rb.velocity = new Vector2(0f, 0f);
        isDashing = false;

        yield return new WaitForSeconds(2f);

        canDash = true;
    }

}
