using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTube : MonoBehaviour
{
    public PoolTube pipePool;

    public float maxTime, heightRange, currentTime;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTube();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= maxTime)
        {
            SpawnTube();
            currentTime = 0;
        }

        currentTime += Time.deltaTime;
    }

    public void SpawnTube()
    {
        GameObject obj = pipePool.GimmeInactiveGameObject();
        if (obj)
        {
            obj.SetActive(true);
            obj.transform.position = transform.position; // La nueva posicion es la del generador 
            obj.transform.position += new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        }
    }
}
