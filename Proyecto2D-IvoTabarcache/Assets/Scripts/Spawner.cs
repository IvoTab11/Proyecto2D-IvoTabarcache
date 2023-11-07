using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    //private GameObject barril;
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, Random.Range(2f,4f));
        //Spawn();
    }

    // Update is called once per frame
    

    public void Spawn(){
        Instantiate(prefab, transform.position, Quaternion.identity);
        //Invoke(nameof(Spawn), Random.Range(2f,4f));
    }

    // void Update()
    // {
    //     if (barril != null && (barril.transform.position.x >= -6.0f) && (barril.transform.position.y >= -6.0f))
    //     {
    //         Destroy(barril);
    //     }
    // }
}
