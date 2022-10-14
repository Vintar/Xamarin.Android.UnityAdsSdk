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
    public class UnityAdsShowListener : Java.Lang.Object, IUnityAdsShowListener
    {
        public void OnUnityAdsShowClick(string p0)
        {
        
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAds.UnityAdsShowCompletionState state)
        {
            //Uncomment for RewardedListener

            //if (state == UnityAds.UnityAdsShowCompletionState.Completed)
            //{
            //    // Reward the user for watching the ad to completion
            //}
            //else
            //{
            //    // Do not reward the user for skipping the ad
            //}
        }

        public void OnUnityAdsShowFailure(string p0, UnityAds.UnityAdsShowError p1, string p2)
        {
        
        }

        public void OnUnityAdsShowStart(string p0)
        {
        
        }
    }
}