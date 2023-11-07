using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona los movimientos horizontales del personaje.
public class Player : MonoBehaviour
{
    //Representa la velocidad de movimiento.
    [SerializeField] private float movementSpeed = 1250f;
    //Representa el valor de mirar a la derecha.
    private bool isFacingRight = true;
    //Referencia al componente Rigidbody2D del personaje.
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      //Se obtiene la entrada de movimiento horizontal.
      float movementX = Input.GetAxis("Horizontal");
      Move(movementX * movementSpeed);
      //El personaje gira si se mueve a la izquierda.
      if(movementX < 0 && isFacingRight){
        Flip();
      }   
      //El personaje gira si se mueve a la derecha.
      else if(movementX > 0 && !isFacingRight){
        Flip();
      }

    
    }

    public void Move(float velocity)
    {
        //Se establece la velocidad para el movimiento horizontal.
        rb.velocity = new Vector2(velocity * Time.deltaTime, rb.velocity.y);
    }

    private void Flip()
    {
      //Cambia la escala en el eje X para voltear al personaje.
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !isFacingRight;
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

    
}
