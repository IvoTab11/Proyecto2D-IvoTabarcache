using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla las animaciones del personaje principal.
public class PlayerAnimations : MonoBehaviour
{
    //Referencia al componente Animator del personaje.
    private Animator animator;
    //Referencia al colisionador del personaje.
    private CapsuleCollider2D capsuleCollider2D;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        capsuleCollider2D=GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
      //Comprueba si nos estamos moviendo hacia la izquierda o la derecha.
      if(Input.GetAxis("Horizontal") != 0)
      {
        //Ejecuta la animación RUN(correr).
        animator.SetBool("isRunning", true);
      }
      else
      {
        //Desactiva la animación RUN.
        animator.SetBool("isRunning", false);
      }
      
      /*Comprueba si nos estamos moviendo hacia arriba o hacia abajo y al mismo tiempo 
      comprueba si estamos colisionando con la capa "Escaleras".*/
      if((Input.GetAxis("Vertical") != 0) && (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Escaleras")))){
        //Ejecuta la animación CLIMB (escalar).
        animator.SetBool("isClimbing", true);
        animator.SetBool("isJumping", false);
      }
      else
      {
        animator.SetBool("isClimbing", false);
        //animator.SetBool("isJumping", false);
      }
      
    }

    //Desactiva la animación de salto si colisiona con un objeto.
    private void OnCollisionEnter2D(Collision2D collision) {
        animator.SetBool("isJumping", false);
    }

    //Activa la animación de salto si no colisiona con ningún objeto.
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isJumping", true);
    }
}
