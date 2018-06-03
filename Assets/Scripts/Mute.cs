using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mute : MonoBehaviour {

    public Sprite Sound;
    public Sprite SoundOff;

	void Start () {
        if (AudioListener.pause == false)
        {
            GetComponent<Image>().sprite = Sound;
        }
        else if (AudioListener.pause == true)
        {
            GetComponent<Image>().sprite = SoundOff;
        }
	}

    public void OnClick()
    {
        if (AudioListener.pause == false)
        {
            AudioListener.pause = true;
            GetComponent<Image>().sprite = SoundOff;
        }
        else if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            GetComponent<Image>().sprite = Sound;
        }
    }
}
