using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Music : MonoBehaviour {

    public AudioSource music;
    
	void Start () {
        DontDestroyOnLoad(this);
        music.Play();
	}
}
