using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _dir;
    private Rigidbody _rb;

    public float speed, maxTime;
    private float currentTime = 0;  
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = speed * _dir;
    }

    private void Update()
    {
        currentTime += Time.deltaTime; 
        if (currentTime >= maxTime)
        {
            currentTime = 0;
            gameObject.SetActive(false); // se devuelve a la pool 
        }
    }

    public void SetDirection(Vector3 value)
    {
        _dir = value;
    }
}
