using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona el comportamiento del objeto Fire;
public class Fire : MonoBehaviour
{
    [SerializeField] private float velocidad = 2.0f;
    [SerializeField] private float distanciaMaxima = 10.0f;

    private Vector3 inicioPosicion;
    private Vector3 destinoPosicion;
    //Indica la dirección en la que se desplaza el objeto. 1 es hacia la derecha y -1 hacia la izquierda.
    private int direccion = 1;

    void Start()
    {
        inicioPosicion = transform.position;
        destinoPosicion = inicioPosicion + Vector3.right * distanciaMaxima;
    }

    void Update()
    {
        // Mueve el personaje en la dirección actual(derecha).
        transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);

        // Comprueba si se ha alcanzado la posición de destino.
        if (direccion == 1 && transform.position.x >= destinoPosicion.x)
        {
            // Cambia la dirección y la posición de destino.
            direccion = -1;
            destinoPosicion = inicioPosicion;
            // Rota el objeto para que mire en la dirección opuesta.
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (direccion == -1 && transform.position.x <= inicioPosicion.x)
        {
            // Cambia la dirección y la posición de destino.
            direccion = 1;
            destinoPosicion = inicioPosicion + Vector3.right * distanciaMaxima;
            // Restaura la rotación para que mire en la dirección original.
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
  
}
