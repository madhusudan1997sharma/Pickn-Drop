using UnityEngine;
using System.Collections;

public class Color : MonoBehaviour {

    float touchTime = 0.0f;
    float untouchTime = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {
        untouchTime += Time.deltaTime;

        if (this.name == "BlueTouched")
        {
            this.transform.position = GameObject.Find("BlueRing").GetComponent<Transform>().position;
            touchTime += Time.deltaTime;

            if (touchTime >= 0.7f)
            {
                Destroy(this.gameObject);
            }
        }
        else if (this.name == "RedTouched")
        {
            this.transform.position = GameObject.Find("RedRing").GetComponent<Transform>().position;
            touchTime += Time.deltaTime;

            if (touchTime >= 0.7f)
            {
                Destroy(this.gameObject);
            }
        }
        else if (this.name == "YellowTouched")
        {
            this.transform.position = GameObject.Find("YellowRing").GetComponent<Transform>().position;
            touchTime += Time.deltaTime;

            if (touchTime >= 0.7f)
            {
                Destroy(this.gameObject);
            }
        }
        else if (this.name == "GreenTouched")
        {
            this.transform.position = GameObject.Find("GreenRing").GetComponent<Transform>().position;
            touchTime += Time.deltaTime;

            if (touchTime >= 0.7f)
            {
                Destroy(this.gameObject);
            }
        }


        else if (this.tag == "Blue" | this.tag == "Red" | this.tag == "Green" | this.tag == "Yellow" && untouchTime >= 5)
        {
            if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            }
            Application.LoadLevel("death");
        }
	}

    void OnMouseDrag()
    {
        if (Time.timeScale == 1)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;
        }
    }
}