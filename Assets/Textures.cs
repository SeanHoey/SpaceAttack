/*
 * author: Sean Hoey x11000759
 * Date:26/03/15
 * */
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Textures : MonoBehaviour {
    private static bool created = false;
    public List<Texture2D> EnemyTexture = new List<Texture2D>();
    string SavePath;

	// Use this for initialization
	void Start () {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
        SavePath = Application.persistentDataPath;
        GetImages();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void GetImages()
    {
        DirectoryInfo info = new DirectoryInfo(SavePath);
        FileInfo[] Files = info.GetFiles();
        for (int i = 0; i < Files.Length; i++)
        {
            Texture2D Image = new Texture2D(2, 2); 
            FileInfo f = Files[i];
            byte[] pic;
            pic = File.ReadAllBytes(SavePath + "/" + f.Name);
            Image.LoadImage(pic);
            AddTexture(Image);
        }
    }
    public void AddTexture(Texture2D t)
    {
        EnemyTexture.Add(t);
    }
}
