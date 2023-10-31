using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
   public float velocidadEscalada = 2f;
    private bool enEscalera = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (enEscalera)
        {
            float inputVertical = Input.GetAxis("Vertical");
            Vector2 movimiento = new Vector2(0, inputVertical * velocidadEscalada);
            rb.velocity = movimiento;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Escalera"))
        {
            Debug.Log("Hola");
            enEscalera = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Escalera"))
        {
            enEscalera = false;
            rb.velocity = Vector2.zero; // Detener la escalada cuando salga de la escalera
        }
    }
}
