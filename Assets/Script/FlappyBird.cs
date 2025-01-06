using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pres = 0.8f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tube"))
        {
            AudioManager.instance.PlayAudio(deathSound, "DeathSound", false, 0.08f);
            Destroy(this);
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
