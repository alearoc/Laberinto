using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorMeta : MonoBehaviour
{
    // Referencia al Canvas UI que muestra la pantalla de victoria
    [SerializeField]
    GameObject pantallaFinal;

    // Referencia al texto en pantalla donde se mostrará el tiempo final
    [SerializeField]
    TextMeshProUGUI textLabelTime;

    // Variables de control para el cronómetro del nivel
    float tiempoDePartida = 0.0f;
    bool estaJugando = true;

    private void Update()
    {
        // Incrementamos el tiempo transcurrido frame a frame mientras el juego siga activo
        if (estaJugando == true)
        {
            tiempoDePartida = tiempoDePartida + Time.deltaTime;
        }
    }

    // Se dispara cuando un objeto entra en el area Trigger (sin colisión física sólida) de la meta
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que atravesó la meta es el jugador
        if (other.tag == "Player")
        {
            // Activamos la pantalla final en la interfaz
            pantallaFinal.SetActive(true);

            // Desactivamos el script de movimiento del jugador para inmovilizarlo al ganar
            other.GetComponent<MovimientoJugador>().enabled = false;

            // Detenemos el cronómetro
            estaJugando = false;

            // Formateamos y enviamos el tiempo acumulado al componente de texto UI
            textLabelTime.text = tiempoDePartida.ToString();
        }
    }
}