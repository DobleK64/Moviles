using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplayManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{

    public static AdDisplayManager instance; // Singletone
    public string unityAdsID; // IDs Del proyecto
    public int androidID, appleID; //IDs de android y Iphone
    public bool testMode = true;

    public string adType = "Interstitial_Android"; //Interstitial_Android , Banner_Android //Tipo de anuncio a mostrar

    public void OnUnityAdsAdLoaded(string placementId) // Callback cuando un anuncio se carga correctamente
    {
        // Muestra el anuncio una vez cargado
        Advertisement.Show(adType, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) // Callback cuando un anuncio no se puede cargar
    {
        //throw new System.NotImplementedException();
        Debug.Log("Ha fallado: " + message);
    }

    public void OnUnityAdsShowClick(string placementId) // Callback cuando el usuario hace clic en el anuncio
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) // Callback cuando un anuncio se muestra completamente
    {
        GameManager.instance.LoadScene("Menu"); // Cuando el anuncio termina, carga la escena del menú
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) // Callback cuando ocurre un error al mostrar un anuncio
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId) // Callback cuando un anuncio comienza a mostrarse
    {
        //throw new System.NotImplementedException();
    }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que este objeto se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    { 
        if (!Advertisement.isInitialized) //Pool de anuncios // Inicializa Unity Ads si aún no está inicializado
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR || UNITY_ANDROID
            Advertisement.Initialize(androidID.ToString(), testMode, this);

#elif UNITY_IOS
            Advertisement.Initialize(appleID.ToString(), testMode, this);
            
#endif
        }
    }

    public void ShowAd() // Método público para mostrar un anuncio
    { 
        if (Advertisement.isInitialized) // Verifica si Unity Ads está inicializado antes de intentar cargar un anuncio
        { 
            Advertisement.Load(adType, this);
        }
    }

    void Update()
    {

    }

    public void OnInitializationComplete() // Callback cuando Unity Ads se inicializa correctamente
    {
        //throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) // Callback cuando falla la inicialización de Unity Ads
    {
        //throw new System.NotImplementedException();
    }
}
