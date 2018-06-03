using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

    public void onClick()
    {
        Destroy(GameObject.Find("Music"));
        Destroy(GameObject.FindGameObjectWithTag("Ads"));
        Application.LoadLevel ("main_menu");
	}
}
