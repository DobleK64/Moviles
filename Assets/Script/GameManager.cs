using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables { POINTS };
    private int points, hits, currentAdd;
    
    private void Awake()
    {
        //SINGLETON
        if (!instance) //si instance no tiene informacion
        {
            instance = this; //instance se asigna a este objeto
            DontDestroyOnLoad(gameObject); // se indica que esre obj no se destruya con la carga de escenas
        }
        else
        {
            Destroy(gameObject); // se destruye el gameobject, para que no haya dos o mas gms en el juego
        }
    }
    private void Start()
    {
        currentAdd = Random.Range(3,6);
    }

    //getter
    public int GetPoints() //recuento de puntos
    {
        return points;
    }

    public int GetHits()
    {
        return hits;
    }
    public int GetAdd()
    {
        return currentAdd;
    }
    //setter
    public void SetPoints(int value)
    {
        points = value;
    }
    public void SetHits(int value)
    { 
        hits = value; 
    }
    public void SetAdd(int value)
    { 
        currentAdd = value; 
    }
    
    //callback ---> funcion que se va a llamar en el onclick() de los botones
    public void LoadScene(string sceneName)
    {
        //oye, audiomanager, limpia todos los sonidos que estan sonando
        AudioManager.instance.ClearAudios();
        SceneManager.LoadScene(sceneName);
        points = 0;
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    //      // getter
    //    public void SetTime(i value)
    //    {
    //        time = value;
    //    }
}
