using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   [SerializeField] private float jumpForce = 1f;
    private bool isGrounded;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
    }
}
