using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

    public Sprite play;
    public Sprite pause;
    public Text paused;

    public void onClick()
    {
        if (Time.timeScale == 1)
        {
			Time.timeScale = 0;
            this.GetComponent<Image>().sprite = play;
            paused.GetComponent<Text>().enabled = true;
            this.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            this.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50, 0);
            this.GetComponent<RectTransform>().localScale = new Vector2(2.2f, 2.2f);
        }
        else
        {
            Time.timeScale = 1;
            this.GetComponent<Image>().sprite = pause;
            paused.GetComponent<Text>().enabled = false;
            this.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            this.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(-35, -35, 0);
            this.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        }
	}
}
