using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public float velocity = 2;
    public Rigidbody rb;
    public float rotationSpeed = 25;
    int pres;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pres = 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce( Vector2.up * velocity * pres);
        if (pres == 1)
            pres = 0;
        transform.rotation = Quaternion.Euler(rb.velocity.y * Time.deltaTime * -rotationSpeed, 90, 0);

    }
}
