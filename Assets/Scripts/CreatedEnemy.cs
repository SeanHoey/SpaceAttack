/*
 * author: Sean Hoey x11000759
 * 
 * */
using UnityEngine;
using System.Collections;

public class CreatedEnemy : MonoBehaviour {
    public float Speed;
    bool alive = true;
    CircleCollider2D CircleCollider;
    Textures TextScript;
    Animator animator;
    // Use this for initialization
    void Start()
    {
        TextScript = GameObject.FindGameObjectWithTag("Texture").GetComponent<Textures>();
        Texture2D t = TextScript.EnemyTexture[UnityEngine.Random.Range(0, TextScript.EnemyTexture.Count)];
        renderer.material.mainTexture = t;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270);
    }

    // Update is called once per frame
    void Update()
    {
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
        MeshRenderer rend = gameObject.GetComponent<MeshRenderer>();
        rend.enabled = false;
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        animator.SetBool("Alive", false);
        audio.Play();
        alive = false;
    }
}
