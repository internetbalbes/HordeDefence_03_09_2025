using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string androidGameId = "5951884";
    [SerializeField] string iOSGameId = "5951885";
    [SerializeField] bool testMode = true;
    private string gameId;

    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
#if UNITY_IOS
        gameId = iOSGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#endif
        Advertisement.Initialize(gameId, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads инициализировано");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Ошибка инициализации: {error.ToString()} - {message}");
    }
}
