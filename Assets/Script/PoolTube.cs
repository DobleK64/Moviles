using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTube : MonoBehaviour
{
    [Tooltip("Object that will go to the pool")]
    public GameObject objectToPool; //Objecto (en este caso tuberias) que a�adimos a la pool
    [Tooltip("Initial pool size")]
    public uint poolSize; //unit = "unisigned int"
    [Tooltip("If true, size increments")]
    public bool shouldExpand = false; //Opcion de expandir la lista, por defecto viene falso, es lo mejor

    private List<GameObject> _pool; //lista de GameObjects

    private void Awake()
    {
        _pool = new List<GameObject>(); //instanciamos la lista

        for (int i = 0; i < poolSize; i++) // Llena la pool inicial con el n�mero de objetos especificado por `poolSize`
        {
            AddGameObjectToPool();
        }
    }

    public GameObject GimmeInactiveGameObject() // M�todo que devuelve un objeto inactivo de la pool
    {
        foreach (GameObject obj in _pool) // Busca en la lista un objeto que est� inactivo
        {
            if (!obj.activeSelf) // Verifica si el objeto no est� activo
            {
                return obj; //Si el objetco no es activo lo damos
            }
        }

        if (shouldExpand) // Si no hay objetos inactivos y la opci�n de expansi�n est� activada
        {
            return AddGameObjectToPool(); // Crea un nuevo objeto y lo devuelve
        }

        return null; // Si no se encuentra un objeto inactivo y no se puede expandir, devuelve null
    }

    private GameObject AddGameObjectToPool() //a�adir GameObject a la pool
    {
        GameObject clone = Instantiate(objectToPool); // Crea una instancia del objeto a pool
        clone.SetActive(false); // Lo desactiva para que no est� visible ni consuma recursos
        _pool.Add(clone);  // A�ade el objeto a la lista de la pool

        return clone; // Devuelve la referencia del objeto reci�n creado
    }
}
