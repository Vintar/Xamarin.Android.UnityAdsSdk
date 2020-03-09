using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace UnityAdsSdkSample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var interstitialAdButton = FindViewById<Button>(Resource.Id.interstitialAdButton);
            interstitialAdButton.Click += InterstitialAdButton_Click;

            var rewardedAdButton = FindViewById<Button>(Resource.Id.rewardedAdButton);
            rewardedAdButton.Click += RewardedAdButton_Click;

            var bannerAdButton = FindViewById<Button>(Resource.Id.bannerAdButton);
            bannerAdButton.Click += BannerAdButton_Click;
        }

        private void InterstitialAdButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(InterstitialAdActivity));
        }

        private void RewardedAdButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RewardedAdActivity));
        }

        private void BannerAdButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(BannerAdActivity));
        }
    }
}