using UnityEngine;
using System.Collections;

public class TakePhoto : MonoBehaviour {
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
        CBG.TakePhoto();
    }
}
