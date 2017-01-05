using UnityEngine;
using System.Collections;

public class Deadnotice : MonoBehaviour {
    public TextMesh Text1, Text2;
	// Use this for initialization
	void Start () {
        Text1 = transform.GetChild(1).gameObject.GetComponent<TextMesh>();
        Text2 = transform.GetChild(2).gameObject.GetComponent<TextMesh>();
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Display()
    {
        int score = PlayerPrefs.GetInt("PlayerScore");
        int highscore=PlayerPrefs.GetInt("HighScore");
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
        }
        Text1.text = "Score " + score;
        Text2.text = "High-Score \n" + highscore;
    }
}
