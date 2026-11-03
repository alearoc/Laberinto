using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionColisionPared : MonoBehaviour
{
    // Material por defecto que se restaurará cuando pase el tiempo
    [SerializeField]
    Material materialParedPorDefecto;

    // Material de impacto que se aplicará al chocar con el jugador
    [SerializeField]
    Material materialParedTocada;

    // Bandera para controlar si el temporizador de reseteo debe estar activo
    bool paredRoja = false;

    // Duración en segundos que la pared permanecerá con el material de choque
    float tiempoenRojo = 5f;

    // Update se ejecuta en cada fotograma del juego
    private void Update()
    {
        // Si la pared fue tocada recientemente, ejecutamos el temporizador
        if (paredRoja == true)
        {
            // Restamos el tiempo transcurrido desde el último frame
            tiempoenRojo = tiempoenRojo - Time.deltaTime;

            // Si el tiempo llega a cero o menos, restauramos el estado original
            if (tiempoenRojo < 0.0f)
            {
                gameObject.GetComponent<MeshRenderer>().material = materialParedPorDefecto;
                paredRoja = false;
                tiempoenRojo = 5f; // Reiniciamos el contador para la próxima colisión
            }
        }
    }

    // Se dispara de forma automática cuando otro objeto con Collider choca físicamente contra esta pared
    private void OnCollisionEnter(Collision col)
    {
        // Comprobamos si el objeto que colisionó tiene la etiqueta "Player"
        if (col.gameObject.tag == "Player")
        {
            // Cambiamos el material visual de la pared al material de choque
            gameObject.GetComponent<MeshRenderer>().material = materialParedTocada;
            paredRoja = true;
        }
    }
}