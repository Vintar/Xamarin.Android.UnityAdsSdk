using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Com.Unity3d.Ads;
using Com.Unity3d.Services.Ads.Api;

namespace UnitySdkSample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class InterstitialAdActivity : AppCompatActivity
    {
        private readonly string _unityGameID = "1234567";
        private readonly string _adUnitId = "your_interstitial_ad_unit_id";
        private readonly bool _isTestMode = true;

        private UnityAdsInitializationListener _unityAdsInitializationListener;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_interstitial_ad);

            // Initialize the Ads SDK:
            _unityAdsInitializationListener = new UnityAdsInitializationListener();
            UnityAds.Initialize(this, _unityGameID, _isTestMode, _unityAdsInitializationListener);

            var showAdButton = FindViewById<Button>(Resource.Id.showAdButton);
            showAdButton.Click += ShowAdButton_Click;
        }

        private void ShowAdButton_Click(object sender, System.EventArgs e)
        {
            if (_unityAdsInitializationListener.IsInitialized)
            {
                DisplayInterstitialAd();
            }
        }

        private void DisplayInterstitialAd()
        {
            //The ad will start to show after the ad has been loaded.
            UnityAds.Load(_adUnitId, new UnityAdsLoadListener(this, _adUnitId));
        }

    }
}