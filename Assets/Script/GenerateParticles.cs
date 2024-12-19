using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParticles : MonoBehaviour
{

    public GameObject particlePrefab;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main; // para llamar a la camara 

    }
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE  // PARA COMPILAR EL CODIGO EN PC
        
        // pc
        if (Input.GetMouseButtonDown(0))
        {
            InstanceParticle(Input.mousePosition, Color.green); 
        }
#elif UNITY_ANDROID // PARA COMPILAR EN ANDROID 
        // para movil 
        foreach (Touch touch in Input.touches) 
        {
            if(touch.phase == TouchPhase.Began) // detectar el toque en pantalla por primera vez
            {
                InstanceParticle(touch.position);
            }
        }
#endif // PARA TERMINAR EL IF 
    }

    void InstanceParticle(Vector3 screenCoords, Color color)
    {
        
        screenCoords.z = 10; // para alejarlo de la camara las unidades que queramos
        Vector3 gameCoords = _cam.ScreenToWorldPoint(screenCoords); // le pasamos las coordenadas a la pantalla 
        GameObject particleClone = Instantiate(particlePrefab, gameCoords, Quaternion.identity); // para instanciar el prefab
        particleClone.GetComponent<Renderer>().material.color = color;
    }
}
