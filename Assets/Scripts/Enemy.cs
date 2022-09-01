using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

   // ENCAPSULATION
   private float walkSpeed = 0.1f;
   public float WalkSpeed
   {
    get { return walkSpeed; }
    protected set { walkSpeed = value; }
   }


   public virtual void DealDamage()
   {
   
   }

   //INHERITANCE
   public virtual void Walk()
   {
    transform.Translate(Vector3.forward * Time.deltaTime * WalkSpeed);
   }
   //INHERITANCE
   public virtual void Jump()
   {

   }


}
