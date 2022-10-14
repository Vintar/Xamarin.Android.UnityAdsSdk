using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Com.Unity3d.Ads;
using Com.Unity3d.Services.Ads.Api;
using static Com.Unity3d.Ads.UnityAds;

namespace UnitySdkSample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RewardedAdActivity : AppCompatActivity
    {
        private readonly string _unityGameID = "1234567";
        private readonly string _adUnitId = "your_rewarded_ad_unit_id";
        private readonly bool _isTestMode = true;

        private UnityAdsInitializationListener _unityAdsInitializationListener;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_rewarded_ad);

            // Initialize the Ads SDK:
            _unityAdsInitializationListener = new UnityAdsInitializationListener();
            Initialize(this, _unityGameID, _isTestMode, _unityAdsInitializationListener);

            var showAdButton = FindViewById<Button>(Resource.Id.showAdButton);
            showAdButton.Click += ShowAdButton_Click;
        }

        private void ShowAdButton_Click(object sender, System.EventArgs e)
        {
            if (_unityAdsInitializationListener.IsInitialized)
            {
                DisplayRewardedAd();
            }
        }

        public void DisplayRewardedAd()
        {
            //The ad will start to show after the ad has been loaded.
            UnityAds.Load(_adUnitId, new UnityAdsLoadListener(this, _adUnitId));
        }

    }
}