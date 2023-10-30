using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // private new Rigidbody2D rigidbody;
    
    // public void Awake(){
    //     rigidbody = GetComponent<Rigidbody2D>(); //Obtenemos el componente Rigidbody2D
    // }

    [SerializeField] private float movementSpeed = 1250f;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float movementX = Input.GetAxis("Horizontal");
      Move(movementX * movementSpeed);

      if(movementX < 0 && isFacingRight){
        Flip();
      }   
      else if(movementX > 0 && !isFacingRight){
        Flip();
      }
    }

    public void Move(float velocity)
    {
        rb.velocity = new Vector2(velocity * Time.deltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !isFacingRight;
    }
}
