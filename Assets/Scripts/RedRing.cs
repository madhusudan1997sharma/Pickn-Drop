using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RedRing : MonoBehaviour {

    public AudioSource Point;
    int score;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Red")
        {
            Point.Play();
            score = PlayerPrefs.GetInt("Score");
            score += 1;
            PlayerPrefs.SetInt("Score", score);
            other.gameObject.name = "RedTouched";
        }
        else
        {
            if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            }
            Application.LoadLevel("death");
        }
    }
}