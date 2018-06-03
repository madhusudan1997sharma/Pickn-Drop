using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    public Text HighScore;
    public GameObject AppTrackerAndroid;
    
    void Update()
    {
        if (RemoveAds.control.adsfree == true)
        {
            Destroy(AppTrackerAndroid.gameObject);
        }
    }

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void onClick()
    {
		Application.LoadLevel("gameplay");
	}
}
