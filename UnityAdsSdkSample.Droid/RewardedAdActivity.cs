using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Com.Unity3d.Ads;
using static Com.Unity3d.Ads.UnityAds;

namespace UnityAdsSdkSample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RewardedAdActivity : AppCompatActivity
    {
        private readonly string _unityGameID = "1234567";
        private readonly string _placementId = "Rewarded";
        private readonly bool _isTestMode = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_rewarded_ad);

            // Initialize the Ads SDK:
            Initialize(this, _unityGameID, new UnityAdsListener(), _isTestMode);

            var showAdButton = FindViewById<Button>(Resource.Id.showAdButton);
            showAdButton.Click += ShowAdButton_Click;
        }

        private void ShowAdButton_Click(object sender, System.EventArgs e)
        {
            DisplayInterstitialAd();
        }

        private void DisplayInterstitialAd()
        {
            if (UnityAds.InvokeIsReady(_placementId))
            {
                UnityAds.Show(this, _placementId);
            }
            else
            {
                Toast.MakeText(this, "Ad not yet loaded", ToastLength.Short);
            }
        }

        // Implement the IUnityAdsListener interface methods:
        private class UnityAdsListener : Java.Lang.Object, IUnityAdsListener
        {
            public void OnUnityAdsError(UnityAdsError p0, string p1)
            {
                // Implement functionality for a Unity Ads service error occurring.
            }

            public void OnUnityAdsFinish(string p0, FinishState p1)
            {
                // Implement functionality for a user finishing an ad.

                if (p1 == FinishState.Completed)
                {
                    // Reward the user for watching the ad to completion.
                }
                else if (p1 == FinishState.Skipped)
                {
                    // Do not reward the user for skipping the ad.
                }
                else if (p1 == FinishState.Error)
                {
                    // Log an error.
                }
            }

            public void OnUnityAdsReady(string p0)
            {
                // Implement functionality for an ad being ready to show.
            }

            public void OnUnityAdsStart(string p0)
            {
                // Implement functionality for a user starting to watch an ad.
            }
        }
    }
}