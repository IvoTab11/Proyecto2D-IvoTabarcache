using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona el salto del personaje.
public class PlayerJump : MonoBehaviour
{
   [SerializeField] private float jumpForce = 1f;
   //Indica si el personaje está en la platafomra
    private bool isGrounded;
    //Referencia al componente Rigidbody2D del personaje.
    private Rigidbody2D rb;
    //Referencia al colisionador del personaje.
    private CapsuleCollider2D capsuleCollider2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D=GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        //Se llama a la función Jump() si el personaje está en una plataforma y si se presiona el boton de saltar
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
           Jump(); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       isGrounded = true; 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    //Permite saltar al personaje.
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
    }
    

}
