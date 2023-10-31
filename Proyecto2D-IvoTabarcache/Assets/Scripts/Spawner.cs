using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(){
        Instantiate(prefab, transform.position, Quaternion.identity);
        Invoke(nameof(Spawn), Random.Range(2f,4f));
    }
}
