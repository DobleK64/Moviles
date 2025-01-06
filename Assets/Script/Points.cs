using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public float currentTime, maxTime;
    public int points;
    public AudioClip pointSound;

    public GameObject invisible;

    public void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= maxTime)
        {
            invisible.gameObject.transform.position += Vector3.up * -10;
            currentTime = 0;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            invisible.gameObject.transform.position += Vector3.up * 10;
            AudioManager.instance.PlayAudio(pointSound, "PointSound", false, 0.08f);
            GameManager.instance.SetPoints(GameManager.instance.GetPoints() + points);

        }
    }
}