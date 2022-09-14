using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Zombie : Enemy
{
    private Animator zombieAnimation;

    // Start is called before the first frame update
    void Start()
    {
        zombieAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //ABSTRACTION
        Walk();
        ZombieAnimation();
    }

    //INHERITANCE FROM ENEMY
    public override void DealDamage()
    {

    }

    //INHERITANCE FROM ENEMY
    public override void Walk()
    {
        //POLYMORPHISM
        base.WalkSpeed = 0.2f;
        base.Walk();

    }

    private void ZombieAnimation()
    {

    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zombieAnimation.SetBool("isAttacking", true);
            Debug.Log("Collided");
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
            zombieAnimation.SetBool("isAttacking", false);
            Debug.Log("Not Colliding");
    }

}
