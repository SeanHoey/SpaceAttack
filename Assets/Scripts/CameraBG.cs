/*
 * author: Sean Hoey x11000759
 * 
 * */
using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class CameraBG : MonoBehaviour {
    public WebCamTexture PhoneCamera;
    public GameObject Text;
    public Texture2D Image;
    Textures TextScript;
    public Vector3 Size = new Vector3(100, 10, 100);
    string SavePath;
    byte[] capture;
    int imagecount = 0;
	// Use this for initialization
	void Start () {
        SetUpCamera();
        SavePath = Application.persistentDataPath;
        TextScript = GameObject.FindGameObjectWithTag("Texture").GetComponent<Textures>();
        GetImages();
	}

    void GetImages()
    {
        DirectoryInfo info = new DirectoryInfo(SavePath);
        FileInfo[] Files=info.GetFiles();
        for (int i = 0; i < Files.Length; i++)
        {
            imagecount++;
        }
    }
    void SetUpCamera()
    {
        PhoneCamera = new WebCamTexture();
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        gameObject.renderer.material.mainTexture = PhoneCamera;
        PhoneCamera.Play();
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void TakePhoto()
    {
        Image = new Texture2D(PhoneCamera.width/2, PhoneCamera.height/2);
        Image.SetPixels(PhoneCamera.GetPixels(160,100, PhoneCamera.width / 2, PhoneCamera.height/2));
        Image.Apply();
        TextScript.AddTexture(Image);
        capture = Image.EncodeToPNG();
        SaveImage(capture);
        //Destroy(Image); 
    }

    public void SaveImage(byte[] b)
    {
        File.WriteAllBytes(Application.persistentDataPath + "/" + imagecount + ".png", b);
        imagecount++;
        StartCoroutine(ShowText());
    }
    IEnumerator ShowText()
    {
        TextMesh t = Text.GetComponent<TextMesh>();
        t.text = "Imaged captured";
        yield return new WaitForSeconds(3f);
        t.text = null;

    }
    public void StopC()
    {
        PhoneCamera.Stop();
    }
}
