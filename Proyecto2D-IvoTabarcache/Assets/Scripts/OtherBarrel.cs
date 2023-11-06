using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBarrel : MonoBehaviour
{
    private float posicionY=-5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer("Plataformas")){
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Barriles2"), LayerMask.NameToLayer("Plataformas"), true);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Barriles")){
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Barriles2"), LayerMask.NameToLayer("Barriles"), true);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Fuegos")){
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Barriles2"), LayerMask.NameToLayer("Fuegos"), true);
        }

    }

    // Update is called once per frame
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
