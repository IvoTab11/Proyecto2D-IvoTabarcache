using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de generar los barriles que se desplazan por las plataformas. 
public class Spawner : MonoBehaviour
{
    //Hace referencia a un objeto en la escena. En este caso será un barril.
    public GameObject prefab;
    
    void Start()
    {
         //Invoca repetidamente al método Spawn.
        InvokeRepeating("Spawn", 0.0f, Random.Range(2f,4f));
    }

    //Genera los barriles.
    public void Spawn(){
        //Instancia los barriles en la escena.
        Instantiate(prefab, transform.position, Quaternion.identity);
        
    }

}
