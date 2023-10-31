using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   [SerializeField] private float jumpForce = 1f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    private Collider2D upperPlatformCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        upperPlatformCollider = GameObject.Find("Platform").GetComponent<Collider2D>();
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
        Physics2D.IgnoreCollision(playerCollider, upperPlatformCollider, !isGrounded);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);

        StartCoroutine("ActivarColision");
    }

    IEnumerator ActivarColision()
    {
        yield return new WaitForSeconds(1);
        // Vuelve a habilitar las colisiones entre el jugador y la plataforma superior
        Physics2D.IgnoreCollision(playerCollider, upperPlatformCollider, false);
    }
}
