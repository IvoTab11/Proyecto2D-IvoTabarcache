using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona el movimiento del personaje principal al escalar.
public class PlayerClimb : MonoBehaviour
{
    [SerializeField] private float velocidadEscalada = 2f;
    private bool escalando;
    //Referencia al componente Rigidbody2D del personaje.
    private Rigidbody2D rb;
    //Almacena la entrada del teclado del jugador para controlar la dirección de la escalada.
    private Vector2 input;
    //Referencia al colisionador del personaje.
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
        input.y=Input.GetAxisRaw("Vertical");
        Escalar();
    }
    
    private void Escalar(){
      //Comprueba si el jugador se está moviendo hacia arriba o hacia abajo, y si está en contacto con la capa "Escaleras".
        if((input.y !=0 || escalando ) && (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Escaleras")))){
            Vector2 velocidadSubida = new Vector2(rb.velocity.x,input.y * velocidadEscalada);
            rb.velocity=velocidadSubida;
            //Se desactiva la gravedad para permitir la escalada.
            rb.gravityScale = 0;
            escalando=true;
            //Ignora las colisiones entre las capas "Plataformas" y "Personaje". Permite que el personaje atraviese las plataformas al escalar.
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Plataformas"), LayerMask.NameToLayer("Personaje"), true);

        }else{
          //Se reestablece la gravedad.
            rb.gravityScale = gravedadInicial;
            escalando=false;
            //Se reestablecen las colisiones.
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Plataformas"), LayerMask.NameToLayer("Personaje"), false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
      //Comprueba si el personaje colisiona con el objetivo
      if(collision.gameObject.CompareTag("Objetivo")){
        enabled=false;
        //Llama a la función LevelComplete() de GameManager.
        FindObjectOfType<GameManager>().LevelComplete();
      //Comprueba si el personaje colisiona con un obstaculo.
      }else if(collision.gameObject.CompareTag("Obstaculo")){
        enabled=false;
        //Llama a la función LevelFailed() de GameManager.
        FindObjectOfType<GameManager>().LevelFailed();

      }
    }
    
}
