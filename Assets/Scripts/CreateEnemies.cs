/*
 * author: Sean Hoey x11000759
 * 
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateEnemies : MonoBehaviour {
    public List<GameObject> EnemiesList = new List<GameObject>();
    public bool PlayerAlive = true;
    public GameObject Created;
    Textures TextScript;
    float CreateTime;
    float RepeatTime = 2.5f;
	// Use this for initialization
	void Start () {
        TextScript = GameObject.FindGameObjectWithTag("Texture").GetComponent<Textures>();
        if (TextScript.EnemyTexture.Count > 0)
        {
            EnemiesList.Add(Created);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > CreateTime&&PlayerAlive==true)
        {
            RepeatTime = UnityEngine.Random.Range(0, 11);
            CreateTime = Time.time + RepeatTime;
            CreateEnemy();
        }
	}
    void CreateEnemy()
    {
        float Random = UnityEngine.Random.Range(-1.5f, 1.5f);
        GameObject Enemy = EnemiesList[UnityEngine.Random.Range(0, EnemiesList.Count)];
        Instantiate(Enemy, new Vector3(Random, 10.5f, -1), new Quaternion(0,0,180,0));
    }

    public void PlayerDead()
    {
        PlayerAlive = false;
    }
}
