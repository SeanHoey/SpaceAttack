/*
 * author: Sean Hoey x11000759
 * 
 * */
using UnityEngine;
using System.Collections;

public class PlayerBeam : MonoBehaviour {
    public float Speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y + (Speed * Time.deltaTime), transform.position.z);
        if(transform.position.y>5){
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.collider2D.tag);
        if (col.collider2D.tag == "Astroid")
        {
            Destroy(gameObject);
        }
        if (col.collider2D.tag == "Enemy")
        {
            int score = PlayerPrefs.GetInt("PlayerScore");
            score += 10;
            PlayerPrefs.SetInt("PlayerScore", score);
            Enemies en = col.gameObject.GetComponent<Enemies>();
            en.destroyEnemy();
            Destroy(gameObject);
        }
        if (col.collider2D.tag == "createdEnemy")
        {
            int score = PlayerPrefs.GetInt("PlayerScore");
            score += 10;
            PlayerPrefs.SetInt("PlayerScore", score);
            CreatedEnemy en = col.gameObject.GetComponent<CreatedEnemy>();
            en.destroyEnemy();
            Destroy(gameObject);
        }
    }
}
