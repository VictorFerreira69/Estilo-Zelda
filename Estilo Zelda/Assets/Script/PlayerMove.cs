using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal, vertical;
    PlayerStatus status;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
          if(horizontal < 0 && transform.localScale.x > 0)
          {
                transform.localScale = new Vector2(transform.localScale.x * -1,transform.localScale.y);
          }
          else if(horizontal > 0 && transform.localScale.x < 0)
          {
              transform.localScale = new Vector2(transform.localScale.x * -1,transform.localScale.y);
          }
      
        bool isWalking = horizontal != 0 || vertical != 0;
        animator.SetBool("isWalking", isWalking);

      
        if (Input.GetButtonDown("Fire1")) 
        {
            animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, vertical) * status.Speed;
    }

    public void TakeHit()
    {
        animator.SetTrigger("Hit");
    }

    public void Die()
    {
        animator.SetTrigger("Death");
        rb.velocity = Vector2.zero; 
    }
}
