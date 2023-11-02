using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
   public float velocidadEscalada = 2f;
    //private bool enEscalera = false;
    private bool escalando;
    private Rigidbody2D rb;
    private Vector2 input;
    private CapsuleCollider2D capsuleCollider2D;
    private float gravedadInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D=GetComponent<CapsuleCollider2D>();
        gravedadInicial=rb.gravityScale;
    }

    void Update()
    {
        // if (enEscalera)
        // {
        //     float inputVertical = Input.GetAxis("Vertical");
        //     Vector2 movimiento = new Vector2(0, inputVertical * velocidadEscalada);
        //     rb.velocity = movimiento;
        // }
        input.y=Input.GetAxisRaw("Vertical");
        Escalar();
    }
    
    private void Escalar(){
        if((input.y !=0 || escalando ) && (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Escaleras")))){
            Vector2 velocidadSubida = new Vector2(rb.velocity.x,input.y * velocidadEscalada);//Si se multiplica por el deltaTime ya no funciona
            rb.velocity=velocidadSubida;
            rb.gravityScale = 0;
            escalando=true;
             Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Plataformas"), LayerMask.NameToLayer("Personaje"), true);

        }else{
            rb.gravityScale = gravedadInicial;
            escalando=false;
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Plataformas"), LayerMask.NameToLayer("Personaje"), false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.CompareTag("Objetivo")){
        enabled=false;
        FindObjectOfType<GameManager>().LevelComplete();

      }else if(collision.gameObject.CompareTag("Obstaculo")){
        enabled=false;
        FindObjectOfType<GameManager>().LevelFailed();

      }
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Escalera"))
    //     {
    //         Debug.Log("Hola");
    //         enEscalera = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("Escalera"))
    //     {
    //         enEscalera = false;
    //         rb.velocity = Vector2.zero; // Detener la escalada cuando salga de la escalera
    //     }
    // }
}
