using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Unity3d.Ads;
using Com.Unity3d.Services.Banners;
using Com.Unity3d.Services.Banners.Api;
using Com.Unity3d.Services.Banners.View;

namespace UnitySdkSample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class BannerAdActivity : AppCompatActivity
    {
        private readonly string _unityGameID = "1234567";
        private readonly string _adUnitId = "your_banner_ad_unit_id";
        private readonly bool _isTestMode = true;

        private Button _showBannerButton;
        private Button _hideBannerButton;
        private RelativeLayout _bannerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_banner_ad);

            _bannerView = FindViewById<View>(Resource.Id.bannerView) as RelativeLayout;

            // Initialize the Ads SDK:
            UnityAds.Initialize(this, _unityGameID, _isTestMode, new UnityAdsInitializationListener());

            _showBannerButton = FindViewById<Button>(Resource.Id.showBanner);
            _hideBannerButton = FindViewById<Button>(Resource.Id.hideBanner);

            _showBannerButton.Click += _showBannerButton_Click;
            _hideBannerButton.Click += _hideBannerButton_Click;
        }

        private void _showBannerButton_Click(object sender, System.EventArgs e)
        {
            // Create the top banner view object:
            var topBanner = new BannerView(this, _adUnitId, new UnityBannerSize(320, 50));
            // Set the listener for banner lifecycle events:
            topBanner.SetListener(new UnityAdsBannerListener());
            LoadBannerAd(topBanner, _bannerView);
        }


        private void _hideBannerButton_Click(object sender, System.EventArgs e)
        {
            // Remove content from the banner view:
            _bannerView.RemoveAllViews();
            // Remove the banner variables:
            _bannerView = null;
        }

        public void LoadBannerAd(BannerView bannerView, RelativeLayout bannerLayout)
        {
            // Request a banner ad:
            bannerView.Load();
            // Associate the banner view object with the banner view:
            bannerLayout.AddView(bannerView);
        }

    }
}