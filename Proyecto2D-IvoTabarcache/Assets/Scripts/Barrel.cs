using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed=1f;
    private float posicionY=-6;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Plataformas")){
         rb.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
        }
    }

    void Update(){
        EliminarBarril();
    }

    private void EliminarBarril(){
        if(this.transform.position.y<=posicionY){
            Destroy(this.gameObject);
        }
    }
}
