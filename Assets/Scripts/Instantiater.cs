using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AppTrackerUnitySDK;

public class Instantiater : MonoBehaviour {

    public GameObject[] Color;
    public Text Score;
    int score;
    float xpos, ypos, xrnd, yrnd;

	// Use this for initialization
	void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Invoke("Maker", 0f);

        if (RemoveAds.control.adsfree != true)
        {
            // Initialize Leadbolt SDK with your API Key
            AppTrackerAndroid.startSession("UGHgCqyAnyqHerqxWXJJVE8HkZXJ1cGU", true);

            // cache Leadbolt Ad without showing it
            AppTrackerAndroid.loadModuleToCache("inapp");
        }
    }
	
	// Update is called once per frame
	void Update () {
        score = System.Int32.Parse(Score.text);
	}

    void Maker()
    {
        xrnd = Random.Range(1, 3);
        yrnd = Random.Range(1, 3);

        if (xrnd == 1)
        {
            xpos = Random.Range(-7, -2);
        }
        else
        {
            xpos = Random.Range(3, 8);
        }

        if (yrnd == 1)
        {
            ypos = Random.Range(3, 4);
        }
        else
        {
            ypos = Random.Range(-4, -2);
        }

        GameObject.Instantiate(Color[Random.Range(0, Color.Length)], new Vector2(xpos, ypos), Quaternion.identity);
        if (score <= 7)
        {
            Invoke("Maker", Random.Range(1, 4));
        }
        else if (score > 7 && score <= 15)
        {
            Invoke("Maker", Random.Range(1, 3));
        }
        else if (score > 15 && score <= 55)
        {
            Invoke("Maker", 1.2f);
        }
        else if (score > 55)
        {
            Invoke("Maker", 1);
        }
        else if (score > 75)
        {
            Invoke("Maker", 0.8f);
        }
        else if (score > 105)
        {
            Invoke("Maker", 0.6f);
        }
        else if (score > 140)
        {
            Invoke("Maker", 0.4f);
        }
        else if (score > 180)
        {
            Invoke("Maker", 0.2f);
        }
        else if (score > 250)
        {
            Invoke("Maker", 0.1f);
        }
    }
}