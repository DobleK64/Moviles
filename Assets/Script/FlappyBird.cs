using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public AudioClip deathSound;
    public float velocity = 2;
    public Rigidbody rb;
    public float rotationSpeed = 25;
    float pres;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

#if UNITY_EDITOR_WIN || UNITY_STANDALONE //PARA QUE FUNCIONE EN PC
        if (Input.GetKeyDown(KeyCode.Space)) // Detecta si se presiona la barra espaciadora
        {
            pres = 0.8f; // Se activa el impulso         
        }

#elif UNITY_ANDROID //PARA QUE FUNCIONE EN ANDROID

        foreach (Touch touch in Input.touches) Itera a través de las pulsaciones en pantalla
        {
            if (touch.phase == TouchPhase.Began) // Detecta si el toque ha comenzado
            {
               pres = 0.8f;  // Se activa el impulso
            }
        }
#endif
    }
    public void Hits()
    {
        AdDisplayManager.instance.ShowAd(); // Muestra un anuncio
        GameManager.instance.SetHits(0); // Reinicia los impactos acumulados
        GameManager.instance.SetAdd(Random.Range(3, 6)); // Establece un nuevo límite aleatorio de impactos antes de mostrar otro anuncio
    }
    private void OnTriggerEnter(Collider other) // Detecta colisiones con otros objetos
    {
        if (other.gameObject.CompareTag("Tube")) // Si el objeto tiene la etiqueta "Tube"
        {
            GameManager.instance.SetHits(GameManager.instance.GetHits() + 1); // Incrementa el contador de impactos
            AudioManager.instance.PlayAudio(deathSound, "DeathSound", false, 0.08f); // Reproduce el sonido de muerte
            Destroy(this); // Destruye este script (desactiva al pájaro)
            if (GameManager.instance.GetHits() >= GameManager.instance.GetAdd())  // Si los impactos acumulados alcanzan el límite
            {
                Hits();
                GameManager.instance.SetHits(0); // Llama al método `Hits` para mostrar un anuncio y reiniciar los impactos
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce( Vector2.up * velocity * pres); // Aplica una fuerza hacia arriba en función del impulso `pres`
        if (pres == 0.8f) // Reinicia el impulso después de aplicarlo
            pres = 0;
        transform.rotation = Quaternion.Euler(rb.velocity.y * Time.deltaTime * -rotationSpeed, 90, 0);
        // Ajusta la rotación del pájaro basándose en su velocidad vertical
    }
}
