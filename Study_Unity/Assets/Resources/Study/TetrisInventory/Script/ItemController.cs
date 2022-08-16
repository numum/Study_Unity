using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] List<ItemData> items;
    [SerializeField] GameObject itemPrefabs_UI;
    [SerializeField] GameObject itemPrefabs;

    public Item CreateItem()
    {
        Item item = Instantiate(itemPrefabs).GetComponent<Item>();

        float x = UnityEngine.Random.Range(-10f, 10f);
        float y = UnityEngine.Random.Range(-5f, 5f);

        item.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
        item.GetComponent<Transform>().localScale = new Vector3(5, 5, 0);


        int selectedItemId = UnityEngine.Random.Range(0, items.Count);
        item.Set_Sprite(items[selectedItemId]);

        item.GetComponent<BoxCollider2D>().size = item.GetComponent<SpriteRenderer>().size;
        item.gameObject.name = item.itemData.name;

        return item;
    }
    
    public Item CreateItemUI(Item interactItem, string itemname)
    {
        Item item = Instantiate(itemPrefabs_UI).GetComponent<Item>();
        item.itemData = interactItem.itemData;

        item.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        item.GetComponent<RectTransform>().localScale = new Vector3(32, 32, 0);

        foreach (var index in items)
        {
            if (index.name == itemname)
            {
                item.Set_Image(index);
            }
        }

        item.gameObject.name = item.itemData.name;
        return item;
    }

}
