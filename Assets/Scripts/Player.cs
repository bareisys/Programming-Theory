using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Rigidbody playerRb;
    private Animator playerAnim;
    private CharacterController controller;

    public float moveSpeed = 1.0f;

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
        Debug.Log(IsOnGround);

    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }
        
    }

    private void Move()
    { 

    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * moveSpeed);
        }

    }


    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }


}
