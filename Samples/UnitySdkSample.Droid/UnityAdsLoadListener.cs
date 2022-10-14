using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Unity3d.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitySdkSample.Droid
{
    public class UnityAdsLoadListener : Java.Lang.Object, IUnityAdsLoadListener
    {
        private Activity _activity;
        private string _adUnitId;

        public UnityAdsLoadListener(Activity activity, string adUnitId)
        {
            _activity = activity;
            _adUnitId = adUnitId;
        }

        public void OnUnityAdsAdLoaded(string p0)
        {
            UnityAds.Show(_activity, _adUnitId, new UnityAdsShowListener());
        }

        public void OnUnityAdsFailedToLoad(string p0, UnityAds.UnityAdsLoadError p1, string p2)
        {
            
        }
    }
}