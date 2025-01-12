using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private List<GameObject> poolList;
    [Tooltip("Initial pool size")]
    public uint poolSize;
    [Tooltip("If true, size increments")]
    public bool shouldExpand = false; // Por si tenemos que expandir la pool
    [Tooltip("Object to add")]
    public GameObject objectToPool;
    // Start is called before the first frame update
    void Start()
    {
        poolList = new List<GameObject>(); // Inicializa la lista que almacenará los objetos
        for (int i = 0; i < poolSize; i++) // Instancia el numero de objetos iniciales especificado por `poolSize`
        {
            AddGameObject(); // Agrega un objeto a la lista
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    GameObject AddGameObject() // Añadir un objeto al pool
    {
        GameObject clone = Instantiate(objectToPool); // Instancia el objeto en el pool
        clone.SetActive(false); // Desactiva el objeto para que no esté disponible hasta que se necesite
        poolList.Add(clone); // Agrega el objeto desactivado a la lista del pool

        return clone; // Devuelve el objeto recién creado
    }

    public GameObject GimmeInactiveGameObject() // Para obtener un objeto inactivo del pool
    {
        foreach (GameObject obj in poolList) // Recorre todos los objetos en el pool
        { 
            if (!obj.activeSelf) // Si el objeto está inactivo, lo devuelve
            {
                return obj; 
            }
        }
        if (shouldExpand) // Si no se encuentra un objeto inactivo y el pool está configurado para expandirse 
        {
            return AddGameObject(); // Agrega un nuevo objeto al pool y lo devuelve
        }
        return null; // Si no se encuentra un objeto inactivo y no se puede expandir el pool, devuelve null

    }
}
