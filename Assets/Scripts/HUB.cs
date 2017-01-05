using UnityEngine;
using System.Collections;

public class HUB : MonoBehaviour {
    int Score=0;
    TextMesh TextM;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("PlayerScore", 0);
        TextM = transform.GetChild(0).gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        Score = PlayerPrefs.GetInt("PlayerScore");
        TextM.text = "Score " + Score;
	}
}
