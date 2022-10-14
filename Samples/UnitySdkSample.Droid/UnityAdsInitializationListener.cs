using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Unity3d.Ads;
using Com.Unity3d.Services.Ads.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitySdkSample.Droid
{
    public class UnityAdsInitializationListener : Java.Lang.Object, IUnityAdsInitializationListener
    {
        public bool IsInitialized { get; private set; }

        public void OnInitializationComplete()
        {
            IsInitialized = true;
        }

        public void OnInitializationFailed(UnityAds.UnityAdsInitializationError p0, string p1)
        {

        }
    }
}