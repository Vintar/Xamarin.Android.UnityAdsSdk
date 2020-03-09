using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Unity3d.Ads;
using Com.Unity3d.Services.Banners;
using Com.Unity3d.Services.Banners.View;

namespace UnityAdsSdkSample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class BannerAdActivity : AppCompatActivity
    {
        private readonly string _unityGameID = "1234567";
        private readonly string _placementId = "Banner";
        private readonly bool _isTestMode = true;
        private View bannerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_banner_ad);

            bannerView = FindViewById<View>(Resource.Id.bannerView);

            // Declare a new banner listener, and set it as the active banner listener:
            UnityBanners.BannerListener = new UnityBannerListener(this);
            // Initialize the Ads SDK:
            UnityAds.Initialize(this, _unityGameID, new UnityAdsListener(), _isTestMode);

            var showAdButton = FindViewById<Button>(Resource.Id.showAdButton);
            showAdButton.Click += ShowAdButton_Click;
        }

        private void ShowAdButton_Click(object sender, System.EventArgs e)
        {
            // If no banner exists, show one; otherwise remove the existing one:
            if (bannerView == null)
            {
                // Optionally specify the banner’s anchor position:
                UnityBanners.SetBannerPosition(BannerPosition.BottomCenter);
                // Request ad content for your Placement, and load the banner:
                UnityBanners.LoadBanner(this, _placementId);
            }
            else
            {
                UnityBanners.Destroy();
                bannerView = null;
            }
        }

        public void LoadBanner()
        {
            // Request ad content for your Placement, and load the banner:
            UnityBanners.LoadBanner(this, _placementId);
        }

        // Implement the banner listener interface methods:
        private class UnityBannerListener : Java.Lang.Object, IUnityBannerListener
        {
            private readonly BannerAdActivity _activity;

            public UnityBannerListener(BannerAdActivity activity)
            {
                _activity = activity;
            }

            public void OnUnityBannerClick(string placementId)
            {
                // Called when the banner is clicked.
            }

            public void OnUnityBannerError(string placementId)
            {
                // Called when an error occurred, and the banner failed to load or show. 
            }

            public void OnUnityBannerHide(string placementId)
            {
                // Called when the banner is hidden from the user.
            }

            public void OnUnityBannerLoaded(string placementId, View view)
            {
                // When the banner content loads, add it to the view hierarchy:
                _activity.bannerView = view;
               // ((ViewGroup)FindViewById(Resource.Id.unityads_example_layout_root)).AddView(view);
            }

            public void OnUnityBannerShow(string placementId)
            {
                // Called when the banner is first visible to the user.
            }

            public void OnUnityBannerUnloaded(string placementId)
            {
                // When the banner’s no longer in use, remove it from the view hierarchy:
                _activity.bannerView = null;
            }
        }

        // Implement the IUnityAdsListener interface methods:
        private class UnityAdsListener : Java.Lang.Object, IUnityAdsListener
        {
            public void OnUnityAdsError(UnityAds.UnityAdsError p0, string p1)
            {
                // Implement functionality for a Unity Ads service error occurring.
            }

            public void OnUnityAdsFinish(string p0, UnityAds.FinishState p1)
            {
                // Implement functionality for a user finishing an ad.
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