using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    public int onPositionX;
    public int onPositionY;

    public void Set_Image(ItemData itemData){
        this.itemData = itemData;
        GetComponent<Image>().sprite = itemData.uiImage;

        Vector2 size = new Vector2();
        size.x = itemData.imageWidth;
        size.y = itemData.imageHeight;

        GetComponent<RectTransform>().sizeDelta = size;
    }

    public void Set_Sprite(ItemData itemData){
        this.itemData = itemData;
        GetComponent<SpriteRenderer>().sprite = itemData.objectSprite;
    }
}
