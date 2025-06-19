using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public string nombre = "Adolescente Perdido";
    public int cantidadAmigosEncontrados = 0;
    public float velocidad = 5f;

    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura input WASD o flechas
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

        if (movimiento != Vector2.zero)
        {
            Mover(movimiento);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }
    }

    public void Mover(Vector2 direccion)
    {
        Vector2 nuevaPos = rb.position + direccion.normalized * velocidad * Time.deltaTime;
        rb.MovePosition(nuevaPos);
    }

    public void Interactuar()
    {
        // Por ahora solo debug, luego raycast o trigger
        Debug.Log($"{nombre} intenta interactuar.");
    }
}
