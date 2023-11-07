using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona el comportamiento de los barriles que caen verticalmente.
public class OtherBarrel : MonoBehaviour
{
    private float posicionY=-5.0f;
    
    // OnCollisionEnter2D() maneja las colisiones con otros objetos.
    private void OnCollisionEnter2D(Collision2D collision){
        // Comprueba si la colisión es con objetos de diferentes capas.
        if(collision.gameObject.layer == LayerMask.NameToLayer("Plataformas")){
            // Ignora la colisión entre la capa "Barriles2" y la capa "Plataformas".
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Barriles2"), LayerMask.NameToLayer("Plataformas"), true);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Barriles")){
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Barriles2"), LayerMask.NameToLayer("Barriles"), true);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Fuegos")){
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Barriles2"), LayerMask.NameToLayer("Fuegos"), true);
        }

    }

    void Update()
    {
        EliminarBarril();
    }
    private void EliminarBarril(){
        if(this.transform.position.y<=posicionY){
            Destroy(this.gameObject);
        }
    }
}
