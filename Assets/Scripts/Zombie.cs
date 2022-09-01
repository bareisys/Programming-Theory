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
        zombieAnimation.SetTrigger("Z_Walk");
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zombieAnimation.SetTrigger("Attack");
            
        }
    }


}
