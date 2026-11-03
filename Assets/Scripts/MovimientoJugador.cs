using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    // Variables públicas para visualizar en el Inspector las fuerzas/entradas de movimiento
    public float movimientoEjeX;
    public float movimientoEjeY;
    public float movimientoEjeZ;

    // Multiplicador para ajustar la velocidad de movimiento del personaje
    public float velocidadMovimiento = 1.5f;

    void Start()
    {
       
    }

    // Update se llama una vez por frame para actualizar la posición según la entrada
    void Update()
    {
        // Lectura de los ejes del Input System (Flechas Izquierda/Derecha)
        // Multiplicamos por Time.deltaTime para mantener la velocidad constante e independiente de los FPS
        movimientoEjeZ = - Input.GetAxis("Horizontal") * Time.deltaTime * velocidadMovimiento;
        
        // Lectura del eje Vertical (Teclas W/S o Flechas Arriba/Abajo)
        movimientoEjeX = Input.GetAxis("Vertical") * Time.deltaTime;

        // Trasladamos el GameObject en su espacio local utilizando los valores calculados
        transform.Translate(movimientoEjeX, movimientoEjeY, movimientoEjeZ);
    }
}