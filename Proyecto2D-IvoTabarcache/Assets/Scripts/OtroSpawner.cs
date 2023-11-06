using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtroSpawner : MonoBehaviour
{
    public GameObject barril;
    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, 3.0f);
        //Invoke("Spawn",2.0f);
        //Spawn();
    }

    private void Spawn(){
        // Genera una posición aleatoria en el eje X entre minX y maxX
        float randomX = Random.Range(-4.40f, 3.6f);
        
        // Configura la posición del barril en la posición aleatoria de X
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(barril, spawnPosition,Quaternion.identity);
    }
}
