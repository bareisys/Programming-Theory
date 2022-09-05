using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Rigidbody playerRb;
    private Animator playerAnim;
    private CharacterController controller;

    private float moveSpeed = 1.0f;

    private bool isOnGround = true;
    //ENCAPSULATION
    public bool IsOnGround
    {
        get { return isOnGround; }
        set { isOnGround = value; }
    }

    private float jumpForce = 3.5f;
    //ENCAPSULATION
    public float JumpForce
    {
        get { return jumpForce; }
        set { jumpForce = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //ABSTRACTION
        Jump();
        Move();
        
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.IsOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            this.IsOnGround = false;
            Debug.Log(this.IsOnGround);

        }
        
    }

    private void Move()
    { 
     if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
         {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            controller.Move(move * Time.deltaTime * moveSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
               
            }
         }

    }


    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            this.IsOnGround = true;
        }
    }


}
