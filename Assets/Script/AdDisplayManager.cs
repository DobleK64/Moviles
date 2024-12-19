using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdDisplayManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener

{
    public static AdDisplayManager instance;
    public string unityAdsID;
    public int androidID, appleID;
    public bool testMode = true;
    public string adType;
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(adType, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Ad failed: " + message);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if(!Advertisement.isInitialized)
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR || UNITY_ANDROID
            Advertisement.Initialize(androidID.ToString(), testMode, this);
           
#elif UNITY_IOS
            Advertisement.Initialize(appleID.ToString(), testMode, this);
          
#endif
        }
    }
    public void ShowAd()
    {
        if(Advertisement.isInitialized)
        {
            Advertisement.Load(adType, this);
            Advertisement.Show(adType, this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
