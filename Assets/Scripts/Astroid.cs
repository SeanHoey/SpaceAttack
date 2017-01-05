using UnityEngine;
using System.Collections;

public class Astroid : MonoBehaviour {
    public float Speed;
    bool Big = false;
    Vector3 SpinDirection;
	// Use this for initialization
	void Start () {
        if (gameObject.name =="Big astroid")
        {
            Big = true;
            SpinDirection = new Vector3(0, 0, UnityEngine.Random.Range(-2, 3));
        }
        if (transform.position.y <= -11.5)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y - (Speed * Time.deltaTime), transform.position.z);
        if (Big)
        {
            transform.Rotate(SpinDirection * (Time.deltaTime*20));
        }
	}
}
