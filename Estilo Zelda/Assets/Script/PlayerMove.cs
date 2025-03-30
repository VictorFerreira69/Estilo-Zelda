using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if ((horizontal > 0 && transform.localScale.x > 0) || (horizontal < 0 && transform.localScale.x < 0))
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        animator.SetBool("isWalking", horizontal != 0 || vertical != 0);
        animator.SetFloat("MoveDirection", vertical > 0 ? 1 : (vertical < 0 ? -1 : 0));

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger(vertical > 0 ? "AttackUp" : (vertical < 0 ? "AttackDown" : "Attack"));
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, vertical) * status.Speed;
    }
}
    
    

