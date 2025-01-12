using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public float tubeSpeed, maxTime, currentTime, resetTime, deathTime;

    public AudioClip fallSound;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * tubeSpeed * Time.deltaTime; // Mueve el tubo hacia la izquierda a una velocidad constante
                                                                         // multiplicada por Time.deltaTime para hacerlo independiente del frame rate
        currentTime += Time.deltaTime; // iniciamos el contador
        if (currentTime >= maxTime) // Si el tiempo actual supera el tiempo máximo permitido
        {
            currentTime = 0; // Reinicia el contador de tiempo
            gameObject.SetActive(false); // Desactiva el objeto y lo devuelve al pool
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FlappyBird>()) // Comprueba si el objeto que colisiona es el pajaro 
        {
            StartCoroutine(Death()); // Inicia la corrutina de muerte
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f); // Espera 0.5 segundos antes de reproducir el sonido
        AudioManager.instance.PlayAudio(fallSound, "FallSound", false, 0.12f); // Reproduce el sonido de caída 
        yield return new WaitForSeconds(1); // Espera 1 segundo antes de recargar la escena
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.LoadScene("Flappy"); // Reinicia el nivel cargando nuevamente la escena del juego
        //AudioManager.instance.ClearAudio();

    }

}
