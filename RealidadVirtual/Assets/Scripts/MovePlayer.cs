using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform target;            // La transformación de la esfera a seguir
    public float smoothSpeed = 0.1f;  // La suavidad del movimiento de la cámara
    public Vector3 offset;              // La distancia entre la esfera y la cámara

    public Transform hole1;
    public int hits = 0;
    public bool point = false;
    private bool isFollowing = false;   // Para rastrear si la cámara debe seguir

    private void Update()
    {
        // Si la esfera se ha detenido (por ejemplo, velocidad cercana a cero)
        if (target.GetComponent<Rigidbody>().velocity.magnitude == 0f)
        {
            isFollowing = true;  // Habilitar el seguimiento de la cámara
        }

        if(point){
            target.position = Vector3.zero;
        }
    }

    private void LateUpdate()
    {
        if (isFollowing)
        {
            // Calcula la posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;

            // Interpola suavemente la posición actual de la cámara hacia la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Aplica la nueva posición a la cámara
            transform.position = smoothedPosition;

            // Mira hacia la esfera
            transform.LookAt(target);
            isFollowing = false;
        }
    }

    void OnTriggerEnter(Collider other){
        //point = true;
        Debug.Log("point");
    }
}
