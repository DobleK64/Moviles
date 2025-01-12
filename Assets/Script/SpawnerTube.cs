using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTube : MonoBehaviour
{
    public PoolTube tubePool;

    public float maxTime, currentTime, heightRange;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTube(); // Genera un tubo inmediatamente al iniciar
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= maxTime) // Si el tiempo transcurrido supera o iguala el tiempo máximo permitido
        {
            SpawnTube();  // Genera un nuevo tubo
            currentTime = 0; // Reinicia el contador de tiempo
        }

        currentTime += Time.deltaTime; // Incrementa el tiempo actual según el tiempo transcurrido en el frame
    }

    public void SpawnTube()
    {
        GameObject obj = tubePool.GimmeInactiveGameObject(); // Solicita un objeto inactivo de la pool
        if (obj)  // Si la pool devuelve un objeto disponible
        {
            obj.SetActive(true); // Activa el objeto (para hacerlo visible y funcional)
            obj.transform.position = transform.position; // Asigna la posición inicial del tubo a la posición del generador
            obj.transform.position += new Vector3(0, Random.Range(-heightRange, heightRange), 0); // Ajusta la posición del tubo en el eje Y con un valor aleatorio dentro del rango especificado
        }
    }
}
