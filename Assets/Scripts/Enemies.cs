/*
 * author: Sean Hoey x11000759
 * 
 * */
using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
    public float Speed;
    bool alive = true;
    CircleCollider2D CircleCollider;
    Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y - (Speed * Time.deltaTime), transform.position.z);
        if (transform.position.y <= -11.5)
        {
            Destroy(gameObject);
        }
        if (alive == false && audio.isPlaying == false)
        {
            Destroy(gameObject);
        }
	}

    public void destroyEnemy()
    {
        CircleCollider = gameObject.GetComponent<CircleCollider2D>();
        CircleCollider.enabled = false;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Alive", false);
        audio.Play();
        alive = false;
    }
}
