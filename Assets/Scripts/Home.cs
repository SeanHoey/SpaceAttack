using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {
    public GameObject BG;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        CameraBG CBG = BG.GetComponent<CameraBG>();
        CBG.StopC();
        Application.LoadLevel(0);
    }
}
