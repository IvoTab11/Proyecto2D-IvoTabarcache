using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
     public float velocidad = 2.0f;
    public float distanciaMaxima = 10.0f;

    private Vector3 inicioPosicion;
    private Vector3 destinoPosicion;
    private int direccion = 1;

    void Start()
    {
        inicioPosicion = transform.position;
        destinoPosicion = inicioPosicion + Vector3.right * distanciaMaxima;
    }

    void Update()
    {
        // Mover el personaje en la dirección actual
        transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);

        // Comprobar si se ha alcanzado la posición de destino
        if (direccion == 1 && transform.position.x >= destinoPosicion.x)
        {
            // Cambiar la dirección y la posición de destino
            direccion = -1;
            destinoPosicion = inicioPosicion;
            // Rotar el objeto para que mire en la dirección opuesta
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (direccion == -1 && transform.position.x <= inicioPosicion.x)
        {
            // Cambiar la dirección y la posición de destino
            direccion = 1;
            destinoPosicion = inicioPosicion + Vector3.right * distanciaMaxima;
            // Restaurar la rotación para que mire en la dirección original
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    
    // public float velocidad = 2.0f;
    // public float distanciaMaxima = 10.0f;

    // private Vector3 inicioPosicion;
    // private Vector3 destinoPosicion;
    // private int direccion = 1;

    // void Start()
    // {
    //     inicioPosicion = transform.position;
    //     destinoPosicion = inicioPosicion + Vector3.right * distanciaMaxima;
    // }

    // void Update()
    // {
    //     // Mover el personaje en la dirección actual
    //     transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);

    //     // Comprobar si se ha alcanzado la posición de destino
    //     if (direccion == 1 && transform.position.x >= destinoPosicion.x)
    //     {
    //         // Cambiar la dirección y la posición de destino
    //         direccion = -1;
    //         destinoPosicion = inicioPosicion;
    //     }
    //     else if (direccion == -1 && transform.position.x <= inicioPosicion.x)
    //     {
    //         // Cambiar la dirección y la posición de destino
    //         direccion = 1;
    //         destinoPosicion = inicioPosicion + Vector3.right * distanciaMaxima;
    //     }
    // }
    
}
