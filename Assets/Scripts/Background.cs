/*
 * author: Sean Hoey x11000759
 * 
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {
    public WebCamTexture PhoneCamera;
    public GameObject Background_object;
    public GameObject Plane_object;
    public GameObject BGView;
    public bool PlayerAlive = true;
    public List<Sprite> Sprites = new List<Sprite>();
    float CreateTime;
    float RepeatTime=5;

	// Use this for initialization
	void Start () {
        CreateTime = Time.time+RepeatTime;
        PhoneCamera = new WebCamTexture();
        if (PhoneCamera != null)
        {
            Destroy(Background_object);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
            Plane_object.renderer.material.mainTexture = PhoneCamera;
            PhoneCamera.Play();
        }
        else
        {
            Destroy(Plane_object);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > CreateTime&&PlayerAlive==true)
        {
            RepeatTime = UnityEngine.Random.Range(0, 11);
            CreateTime = Time.time + RepeatTime;
            CreateBG();
        }
	}

    void CreateBG()
    {
        GameObject Obj;
        BGObjectMove move;
        float Random = UnityEngine.Random.Range(-2f, 2f);
        Obj = (GameObject)Instantiate(BGView, new Vector3(Random, 10.5f, transform.position.z - 1), Quaternion.identity);
        move = Obj.GetComponent<BGObjectMove>();
        Sprite s = Sprites[UnityEngine.Random.Range(0, Sprites.Count)];
        move.ChangeSprite(s);
    }

    public void PlayerDead()
    {
        PlayerAlive = false;
        PhoneCamera.Stop();
    }
}
