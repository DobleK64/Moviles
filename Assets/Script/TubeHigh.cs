using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeHigh : MonoBehaviour
{

    public AudioClip fallSound;
    public void OnTriggerEnter(Collider other) // Metodo que se ejecuta cuando otro objeto entra en el trigger de este objeto
    {
        if (other.gameObject.GetComponent<FlappyBird>()) // Verifica si el objeto que colisiono tiene el componente FlappyBird
        {
            StartCoroutine(Death()); // Inicia la corrutina para manejar la "muerte" del jugador
        } 
    }

    IEnumerator Death() // Corrutina que maneja la secuencia de muerte
    {
        yield return new WaitForSeconds(0.5f); // Espera medio segundo antes de reproducir el sonido de caída
        AudioManager.instance.PlayAudio(fallSound, "FallSound", false, 0.12f);  // Reproduce el sonido de caída
        yield return new WaitForSeconds(1); // Espera un segundo más antes de reiniciar la escena
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.LoadScene("Flappy");  // Carga la escena del juego nuevamente para reiniciar el nivel
        //AudioManager.instance.ClearAudio();

    }
}
