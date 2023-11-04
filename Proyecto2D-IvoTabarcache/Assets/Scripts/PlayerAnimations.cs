using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private CapsuleCollider2D capsuleCollider2D;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        capsuleCollider2D=GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
      if(Input.GetAxis("Horizontal") != 0)
      {
        animator.SetBool("isRunning", true);
      }
      else
      {
        animator.SetBool("isRunning", false);
      }

      if((Input.GetAxis("Vertical") != 0) && (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Escaleras")))){
        animator.SetBool("isClimbing", true);
      }
      else
      {
        animator.SetBool("isClimbing", false);
      }


      //---------------------------------------
      // if(capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Escaleras"))){
      //   animator.SetBool("isClimbing", true);
      // }
      // else
      // {
      //   animator.SetBool("isClimbing", false);
      // }
      //-----------------------------------
      // if (Input.GetAxis("Vertical") != 0)
      // {
      //   animator.SetBool("isClimbing", true);
      // }
      // else
      // {
      //   animator.SetBool("isClimbing", false);
      // }
      
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        animator.SetBool("isJumping", false);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isJumping", true);
    }
}
