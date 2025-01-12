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
        transform.position += Vector3.left * tubeSpeed * Time.deltaTime; // Movemos la tuberia hacia la izquierda a una velocidad constante

        currentTime += Time.deltaTime; // iniciamos el contador
        if (currentTime >= maxTime) // si el tiempo actual supera el max time
        {
            currentTime = 0; // igualamos a 0 el contador
            gameObject.SetActive(false); //Se "devuelve" a la pool
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FlappyBird>())
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.PlayAudio(fallSound, "FallSound", false, 0.12f);
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.LoadScene("Flappy");
        //AudioManager.instance.ClearAudio();

    }

}
