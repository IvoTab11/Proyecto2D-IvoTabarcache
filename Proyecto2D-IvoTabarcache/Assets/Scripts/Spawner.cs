using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    //private GameObject barril;
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    

    public void Spawn(){
        Instantiate(prefab, transform.position, Quaternion.identity);
        Invoke(nameof(Spawn), Random.Range(2f,4f));

        // if ((transform.position.x >= -6.0f) && (transform.position.y>=-6.0f))
        // {
        //     // Destruye el objeto cuando alcanza la posición destino.
        //     Destroy(prefab);
        // }
        // if ((barril.transform.position.x >= -6.0f) && (barril.transform.position.y >= -6.0f))
        // {
        //     Destroy(barril);
        // }
    }

    // void Update()
    // {
    //     if (barril != null && (barril.transform.position.x >= -6.0f) && (barril.transform.position.y >= -6.0f))
    //     {
    //         Destroy(barril);
    //     }
    // }
}
