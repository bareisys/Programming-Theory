using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Rigidbody playerRb;
    private Animator playerAnim;

    private bool isOnGround = true;
    public bool IsOnGround
    {
        get { return isOnGround; }
        set { isOnGround = value; }
    }

    private float jumpForce = 3.5f;
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
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }



    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.IsOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            this.IsOnGround = false;
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
