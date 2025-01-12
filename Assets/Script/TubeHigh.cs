using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeHigh : MonoBehaviour
{

    public AudioClip fallSound;
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
