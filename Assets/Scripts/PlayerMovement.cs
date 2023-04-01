using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer sprite;
    private CapsuleCollider2D collider;

    private float directionX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpFactor = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private enum CurrentMovement { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
       rigidBody = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       sprite = GetComponent<SpriteRenderer>();
       collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //variable to hold the horizontal movement factor
        directionX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(directionX*moveSpeed, rigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
         {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpFactor);
         }

         UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
      CurrentMovement state;

      if (directionX > 0f) //if moving right
      {
         state = CurrentMovement.running;
         sprite.flipX = false;
      }
      else if (directionX < 0f) //if moving left
      {
         state = CurrentMovement.running;
         sprite.flipX = true;
      }
      else 
      {
         state = CurrentMovement.idle; //if not moving
      }

      if (rigidBody.velocity.y > .1f) //if jumping
      {
         state = CurrentMovement.jumping;
      }
      else if (rigidBody.velocity.y < -.1f) //if falling
      {
         state = CurrentMovement.falling;
      }

      animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
      return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
