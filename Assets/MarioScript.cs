using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour
{
    public Rigidbody2D rb; // Referencia al componente Rigidbody2D

    void Start()
    {
        // Obtener el componente Rigidbody2D del objeto
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody2D en el objeto.");
        }
    }

    void Update()
    {
        // Obtener la entrada de los botones de flecha (izquierda y derecha)
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcular el desplazamiento horizontal
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0f) * 5f * Time.deltaTime;

        // Aplicar el desplazamiento horizontal al objeto
        transform.Translate(movimiento);

        // Verificar si la posición en Y es menor o igual que la altura máxima permitida para saltar
        if (transform.position.y <= 10)
        {
            // Verificar si se ha presionado la flecha hacia arriba y permitir el salto
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Aplicar fuerza de salto al objeto
                rb.AddForce(Vector2.up * 90f, ForceMode2D.Impulse);
            }
        }
    }
}
