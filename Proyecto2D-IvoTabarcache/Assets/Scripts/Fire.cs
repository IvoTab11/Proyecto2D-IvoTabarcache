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
        }
        else if (direccion == -1 && transform.position.x <= inicioPosicion.x)
        {
            // Cambiar la dirección y la posición de destino
            direccion = 1;
            destinoPosicion = inicioPosicion + Vector3.right * distanciaMaxima;
        }
    }
    //  public float velocidad = 2.0f;
    // public float distanciaMaxima = 10.0f;

    // private Vector3 inicioPosicion;
    // private Vector3 destinoPosicion;

    // void Start()
    // {
    //     inicioPosicion = transform.position;
    //     destinoPosicion = inicioPosicion + Vector3.right * distanciaMaxima;

    //     StartCoroutine(MoverPersonaje());
    // }

    // IEnumerator MoverPersonaje()
    // {
    //     while (true)
    //     {
    //         while (transform.position != destinoPosicion)
    //         {
    //             transform.position = Vector3.MoveTowards(transform.position, destinoPosicion, velocidad * Time.deltaTime);
    //             yield return null;
    //         }

    //         // Intercambiar las posiciones de inicio y destino para el movimiento de regreso
    //         Vector3 temp = inicioPosicion;
    //         inicioPosicion = destinoPosicion;
    //         destinoPosicion = temp;
    //         yield return null;
    //     }
    // }
}
