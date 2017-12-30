using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage : MonoBehaviour {
    string url = "http://www.dccomics.com/sites/default/files/styles/character_thumb_160x160/public/CharThumb_Rebirth_Superman_586ee06eddc447.49308496.jpg?itok=VvQpy2_u";
    Texture2D img;

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadImg());	
	}

    IEnumerator LoadImg()
    {
        //Check internet
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            yield return null;
        }
        yield return 0;
        WWW imgLink = new WWW(url);
        yield return imgLink;
        img = new Texture2D(1, 1);
        imgLink.LoadImageIntoTexture(img);

        Sprite sprite = Sprite.Create(img,
            new Rect(0, 0, img.width, img.height),
            Vector2.one / 2);
        //img = imgLink.texture;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }


}
