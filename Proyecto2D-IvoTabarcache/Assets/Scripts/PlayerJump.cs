using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   [SerializeField] private float jumpForce = 1f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider2D;
   // private Collider2D upperPlatformCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D=GetComponent<CapsuleCollider2D>();
        //upperPlatformCollider = GameObject.Find("Platform").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public void Jump()
    {
        //Physics2D.IgnoreCollision(playerCollider, upperPlatformCollider, !isGrounded);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Plataformas"), LayerMask.NameToLayer("Personaje"), true);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);

        //StartCoroutine("ActivarColision");
         StartCoroutine(RestoreCollision());
    }
    
    private IEnumerator RestoreCollision()
{
    yield return new WaitForSeconds(1);  // Ajusta el tiempo necesario para que las colisiones se restauren adecuadamente

    // Restaura las colisiones entre el personaje y las plataformas
    Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Personaje"), LayerMask.NameToLayer("Plataformas"), false);
}
    // IEnumerator ActivarColision()
    // {
    //     yield return new WaitForSeconds(1);
    //     // Vuelve a habilitar las colisiones entre el jugador y la plataforma superior
    //     Physics2D.IgnoreCollision(playerCollider, upperPlatformCollider, false);
    // }
}
