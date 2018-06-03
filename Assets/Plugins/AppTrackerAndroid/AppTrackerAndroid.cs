using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace AppTrackerUnitySDK {

	public class AppTrackerAndroid : MonoBehaviour {
	#if UNITY_ANDROID
		private static AndroidJavaObject appTracker;

		void Awake()
		{
			//gameObject.name = "AppTrackerAndroid";
			DontDestroyOnLoad(this);

			initializeAppTracker ();
		}

		private static void initializeAppTracker()
		{
			AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			appTracker = new AndroidJavaObject("com.apptracker.unity.android.AppTrackerUnity", jo);
		}

		public static void startSession(string apikey)
		{
			//initializeAppTracker();
			appTracker.Call("startSession",apikey, false); 
		}

		public static void startSession(string apikey, bool autoRecache)
		{
			appTracker.Call ("startSession", apikey, autoRecache);
		}

		public static void closeSession(bool sync)
		{
			if(appTracker != null)
				appTracker.Call("closeSession", sync);
		}
		public static void pause()
		{
			if(appTracker != null)
				appTracker.Call("pause");
		}
		public static void resume()
		{
			if(appTracker != null)
				appTracker.Call("resume");
		}
		public static void Event(string name)
		{
			if(appTracker != null)
				appTracker.Call("event", name);
		}
		public static void Event(string name, float value)
		{
			if(appTracker != null)
				appTracker.Call("event", name, value);
		}
		public static void transaction(string name, float value, string currencycode)
		{
			if(appTracker != null)
				appTracker.Call("transaction", name, value, currencycode);
		}
		public static void loadModule(string locationcode)
		{
			if(appTracker != null)
				appTracker.Call("loadModule", locationcode);
		}
		public static void loadModule(string location, string userdata)
		{
			if(appTracker != null)
				appTracker.Call("loadModule", location, userdata);
		}
		public static void loadModuleToCache(string locationcode)
		{
			if(appTracker != null)
				appTracker.Call("loadModuleToCache", locationcode);
		}
		public static void loadModuleToCache(string location, string userdata)
		{
			if(appTracker != null)
				appTracker.Call("loadModuleToCache", location, userdata);
		}
		public static void destroyModule()
		{
			if(appTracker != null)
				appTracker.Call("destroyModule");
		}

		public static void fixAdOrientation(AdOrientation orientation)
		{
			if(appTracker != null)
			{
				appTracker.Call("fixAdOrientation",(int)orientation);
			}
		}

		public static void setAgeRange(string range) {
			if (appTracker != null) {
				appTracker.Call ("setAgeRange", range);
			}
		}

		public static void setGender(string gender) {
			if (appTracker != null) {
				appTracker.Call ("setGender", gender);
			}
		}

		public static bool isAdReady(string location) {
			return appTracker.Call<bool> ("isAdReady", location);
		}

		public enum AdOrientation {
			AdOrientation_AutoDetect = 0,
			AdOrientation_Landscape = 1,
			AdOrientation_Portrait = 2
		};

		public static event Action<string> onModuleLoadedEvent;
		public static event Action<string,string,bool> onModuleFailedEvent;
		public static event Action<string> onModuleClosedEvent;
		public static event Action<string> onModuleCachedEvent;
		public static event Action<string> onModuleClickedEvent;
		public static event Action<bool>onMediaFinishedEvent;
		
		public void onModuleLoaded(string message)
		{
			Debug.Log ("AppTrackerAndroid - onModuleLoaded:" + message);

			if(onModuleLoadedEvent != null)
				onModuleLoadedEvent(message);
		}

		public void onModuleFailed(string message)
		{
			Debug.Log ("AppTrackerAndroid - onModuleFailed:" + message);
			string[] names = message.Split (':');
			if (onModuleFailedEvent != null) {
				onModuleFailedEvent(names[0],names[1],"1".Equals(names[2])?true:false);
			}
		}

		public void onModuleClosed(string message)
		{
			Debug.Log ("AppTrackerAndroid - onModuleClosed:"+ message);
			if(onModuleClosedEvent != null)
				onModuleClosedEvent(message);
		}
		public void onModuleCached(string message)
		{
			Debug.Log ("AppTrackerAndroid - onModuleCached:"+ message);
			if(onModuleCachedEvent != null)
				onModuleCachedEvent(message);
		}
		public void onMediaFinished(string message)
		{
			Debug.Log("AppTrackerAndroid - onMediaFinished:"+message);
			if(onMediaFinishedEvent != null)
				onMediaFinishedEvent("1".Equals(message));
		}
		public void onModuleClicked(string msg) {
			Debug.Log("AppTrackerAndroid - onModuleClicked:"+msg);
			if(onModuleClickedEvent != null)
				onModuleClickedEvent(msg);
		}
	#endif
	}
}