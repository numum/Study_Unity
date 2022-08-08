using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoad : MonoBehaviour
{
    
    void Start()
    {
        ImageLoader imageLoader = ImageLoader.Instance;
        GameObject Red = GameObject.Find("Red");
        GameObject Blue = GameObject.Find("Blue");
        GameObject Green = GameObject.Find("Green");

        Red.GetComponent<SpriteRenderer>().sprite = imageLoader.Red;
        Blue.GetComponent<SpriteRenderer>().sprite = imageLoader.Blue;
        Green.GetComponent<SpriteRenderer>().sprite = imageLoader.Green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class ImageLoader{
    private static ImageLoader instance;
    private Texture2D texture;

    public static ImageLoader Instance{
        get{
            if(instance == null){
                instance = new ImageLoader();
            }
            return instance;
        }
    }

    public Sprite Red{
        get{
            SysIOFileLoad(System.IO.Path.Combine(Application.streamingAssetsPath,"Image/Red.png"));
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }
    public Sprite Blue
    {
        get
        {
            SysIOFileLoad(System.IO.Path.Combine(Application.streamingAssetsPath, "Image/Blue.png"));
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }
    public Sprite Green
    {
        get
        {
            SysIOFileLoad(System.IO.Path.Combine(Application.streamingAssetsPath, "Image/Green.png"));
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }

    private void SysIOFileLoad(string path)
    {
        byte[] byteTexture = System.IO.File.ReadAllBytes(path);
        if (byteTexture.Length > 0)
        {
            texture = new Texture2D(0, 0);
            texture.LoadImage(byteTexture);
        }
    }
}
