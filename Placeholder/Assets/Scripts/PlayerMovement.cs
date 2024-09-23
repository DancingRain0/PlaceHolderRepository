using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private float horizontal;
        private float speed = 6f;
        private float sprintSpeed = 9f;
        public float Deafaultjumpingpower = 6f;
        public float jumpingpower;
        private bool isFacingRight = true;
        public Animator animator;
        private PickupScript Pickup;
       

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        private bool isSprinting = false;
        private bool jumpBoostActive = false;
        public bool isThrowing = false;

  

        void Start()
        {
            jumpingpower = Deafaultjumpingpower; //Inital Jump strength
            Pickup = gameObject.GetComponent<PickupScript>();
            Pickup.pickupPosition = new Vector2 (+.7f, 0);
        }







       void Update()
       {
           horizontal = Input.GetAxisRaw("Horizontal");
           animator.SetFloat("Speed", Mathf.Abs(horizontal));

            
          

            bool isMoving = Mathf.Abs(horizontal) > 0.01f;
            isSprinting = Input.GetKey(KeyCode.LeftShift);
            isThrowing = Input.GetKey(KeyCode.X);

            if (isMoving) 
            {
                animator.SetBool("IsMoving", true);
                
            }

            else
            {
                animator.SetBool("IsMoving", false);
               
            }


            if (isSprinting)
            {
                animator.SetBool("IsRunning", true);
                animator.SetFloat("Speed", 2);
               
            }
            else
            {
                animator.SetBool("IsRunning", false) ;
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
             
            }
        


            if (isSprinting && !isMoving)
            {
                animator.SetBool("IsRunning", true);
                animator.SetFloat("Speed", 0); // Set speed to 0 when standing still but holding sprint key
            }
                 else if (isSprinting && isMoving)
                 {
             
                animator.SetBool("IsRunning", true);
                  animator.SetFloat("Speed", 2);               
                 }
            else if(isMoving)
                {
                animator.SetBool("IsRunning", false);
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
                }
            else
            {
                animator.SetBool("IsRunning", false);
                animator.SetFloat("Speed", 0);
            }




            if (isThrowing)
            {
                animator.SetBool("IsThrowing", true);               
                isThrowing = false;
            }
            else if (!isThrowing)
            {
                animator.SetBool("IsThrowing", false);
            }



            bool grounded = IsGrounded();

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsFalling", false);
                
                
                if (jumpBoostActive)
                {
                    Resetjumpingpower();
                }


            }
           else if (Input.GetButtonDown("Jump") && isSprinting && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsFalling", false);


                if (jumpBoostActive)
                {
                    Resetjumpingpower();
                }


            }
            else if (!IsGrounded())
            {
                if (rb.velocity.y < 0)
                {
                    animator.SetBool("IsFalling", true);
                    animator.SetBool("IsJumping", false);
                }
                else if (rb.velocity.y > 0)
                {
                    animator.SetBool("IsJumping", true);
                    animator.SetBool("IsFalling", false);
                }
            }
            else
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
            }

        





            Flip();
        }










        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        private void FixedUpdate()
        {

            if (isThrowing)
            {
               
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else
            {
               
                float currentSpeed = isSprinting ? sprintSpeed : speed;
                rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
            }
        }

        private void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector2 localscale = transform.localScale;
                localscale.x *= -1f;
                transform.localScale = localscale;
            }
        }
        public void Setjumpingpower(float newjumpingpower)
        {
            jumpingpower = newjumpingpower;
           
        }
        public void SetJumpBoost(float boostAmount)
        {
            jumpingpower = boostAmount;
            jumpBoostActive = true;
        }

        public void Resetjumpingpower()
        {
            jumpingpower = Deafaultjumpingpower;
            jumpBoostActive = false;
        }
        public float GetJumpingPower()
        {
            return jumpingpower;
        }
    }
}