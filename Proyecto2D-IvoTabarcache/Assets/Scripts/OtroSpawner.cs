using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de generar los barriles que caen verticalmente. 
public class OtroSpawner : MonoBehaviour
{
    //Hace referencia a un objeto en la escena. En este caso será un barril.
    public GameObject barril;
    void Start()
    {
        //Invoca repetidamente al método Spawn.
        InvokeRepeating("Spawn", 2.0f, 3.0f);
    }

    //Genera los barriles.
    private void Spawn(){
        // Genera una posición aleatoria en el eje X.
        float randomX = Random.Range(-4.40f, 3.6f);
        
        // Configura la posición del barril en la posición aleatoria de X
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        //Instancia los barriles en la escena.
        Instantiate(barril, spawnPosition,Quaternion.identity);
    }
}
