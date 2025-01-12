using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public float currentTime, maxTime;
    public int points;
    public AudioClip pointSound;

    public GameObject checkpoint;

    public void Update()
    {
        currentTime += Time.deltaTime;  // Incrementa el tiempo actual según el tiempo transcurrido en el frame

        if (currentTime >= maxTime) // Verifica si el tiempo actual ha alcanzado el tiempo máximo
        {
            checkpoint.gameObject.transform.position += Vector3.up * -10; // Baja el checkpoint 10 unidades
            currentTime = 0; // Resetea el tiempo actual a 0
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Verifica si el objeto que colisionó tiene la etiqueta "Player"
        {

            checkpoint.gameObject.transform.position += Vector3.up * 10; // Sube el checkpoint 10
            AudioManager.instance.PlayAudio(pointSound, "PointSound", false, 0.08f); // Reproduce el sonido asociado al punto
            GameManager.instance.SetPoints(GameManager.instance.GetPoints() + points); // Incrementa los puntos del jugador

        }
    }
}