using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo sobre el eje Y
    [SerializeField]
    float RotacionY = 10f;

    // Update es llamado en cada frame para realizar el giro continuo
    void Update()
    {
        // Hace rotar el objeto sobre el eje Y.
        // Multiplicar por Time.deltaTime asegura que el giro sea suave y constante sin importar los fotogramas del dispositivo.
        transform.Rotate(0.0f, RotacionY * Time.deltaTime, 0f);
    }
}