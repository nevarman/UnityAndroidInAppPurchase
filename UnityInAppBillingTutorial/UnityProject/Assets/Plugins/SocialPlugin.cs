//#define DEBUGMODE // CLOSE ON RELEASE!
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class SocialPlugin : MonoBehaviour 
{
#if !DEBUGMODE && UNITY_IOS
	[DllImport("__Internal")]
	private static extern void shareOnFacebook();
	[DllImport("__Internal")]
	private static extern void shareOnTwitter();
	[DllImport("__Internal")]
	private static extern void buyCoins(int num);
	[DllImport("__Internal")]
	private static extern void getCoinData();

#endif

#if !DEBUGMODE && UNITY_ANDROID
	private static AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
	private static AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
#endif

	public static void callShareOnFacebook()
	{
		#if !DEBUGMODE && UNITY_IOS
		shareOnFacebook();
		#elif !DEBUGMODE && UNITY_ANDROID
		jo.Call("shareOnFacebook");
		#endif
	}
	public static void callShareOnTwitter()
	{
		#if !DEBUGMODE && UNITY_IOS
		shareOnTwitter();
		#elif !DEBUGMODE && UNITY_ANDROID
		jo.Call("shareOnTwitter");
		#endif
	}
	public static void callBuyCoins(int num)
	{
		#if !DEBUGMODE && UNITY_IOS
		shareOnTwitter();
		#elif !DEBUGMODE && UNITY_ANDROID
		Debug.Log("Buy coins called for "+ num) ;
		jo.Call("buyCoins",num);
		#endif
	}
	public static int callGetCoinData()
	{
		#if !DEBUGMODE && UNITY_IOS
		getCoinData();
		#elif !DEBUGMODE && UNITY_ANDROID
		return jo.Call<int>("getCoinData");
		#endif
	}

}
