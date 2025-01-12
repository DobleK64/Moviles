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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pres = 0.8f;         
        }

#elif UNITY_ANDROID //PARA QUE FUNCIONE EN ANDROID

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
               pres = 0.8f;  
            }
        }
#endif
    }
    public void Hits()
    {
        AdDisplayManager.instance.ShowAd();
        GameManager.instance.SetHits(0);
        GameManager.instance.SetAdd(Random.Range(3, 6));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tube"))
        {
            GameManager.instance.SetHits(GameManager.instance.GetHits() + 1);
            AudioManager.instance.PlayAudio(deathSound, "DeathSound", false, 0.08f);
            Destroy(this);
            if (GameManager.instance.GetHits() >= GameManager.instance.GetAdd()) 
            {
                Hits();
                GameManager.instance.SetHits(0);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce( Vector2.up * velocity * pres);
        if (pres == 0.8f)
            pres = 0;
        transform.rotation = Quaternion.Euler(rb.velocity.y * Time.deltaTime * -rotationSpeed, 90, 0);

    }
}
