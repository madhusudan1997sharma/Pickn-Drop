using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AppTrackerUnitySDK;

public class Replay : MonoBehaviour
{
    public Text Score;
    public Text NewBest;

    void Start()
    {
        if (RemoveAds.control.adsfree != true)
        {
            try
            {
                //Requesting LeadBolt Ads
                if (AppTrackerAndroid.isAdReady("inapp"))
                {
                    AppTrackerAndroid.loadModule("inapp");
                }
            }
            catch
            {

            }
        }

        Score.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
        {
            NewBest.GetComponent<Text>().enabled = true;
        }
        else if (PlayerPrefs.GetInt("Score") < PlayerPrefs.GetInt("HighScore"))
        {
            NewBest.GetComponent<Text>().enabled = false;
        }
    }

    public void onClick()
    {
        Application.LoadLevel("gameplay");
    }
}
