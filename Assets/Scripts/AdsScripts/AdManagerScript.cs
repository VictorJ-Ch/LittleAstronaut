using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdManagerScript : MonoBehaviour
{
     // These ad units are configured to always serve test ads.
    #if UNITY_ANDROID
        private string _adUnitIdBanner = "ca-app-pub-3940256099942544/6300978111";
        //ID ad for tests "ca-app-pub-3940256099942544/6300978111" !important for development.
        //ID app for launches "ca-app-pub-5246086837419417/9077408737"
    #elif UNITY_IPHONE
        private string _adUnitIdBanner = "ca-app-pub-3940256099942544/2934735716";
    #else
    private string _adUnitIdBanner = "unused";
    #endif

    BannerView _bannerView;
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            RequestBanner();
        });
    }

    void Update()
    {
        
    }

    public void RequestBanner()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            _bannerView.Destroy();
        }

        // Create a 320x50 banner at bottom of the screen
        _bannerView = new BannerView(_adUnitIdBanner, AdSize.Banner, AdPosition.Bottom);

        var adRequest = new AdRequest();

        _bannerView.LoadAd(adRequest);
    }

    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        _bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + _bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
                RequestBanner();
        };
        // Raised when the ad is estimated to have earned money.
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        _bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        _bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        _bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        _bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }
}
