using UnityEngine;
using System.Collections;

public class BGObjectMove : MonoBehaviour {
    public float Speed;
    SpriteRenderer Rend;
	// Use this for initialization
	void Start () {
        Speed = UnityEngine.Random.Range(5, 11);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y - (Speed * Time.deltaTime), transform.position.z);
        if (transform.position.y <= -11.5)
        {
            Destroy(gameObject);
        }
	}

    public void ChangeSprite(Sprite X)
    {
        Rend = gameObject.GetComponent<SpriteRenderer>();
        Rend.sprite = X;
    }
    
}
