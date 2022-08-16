using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject invenPrefabs;
    
    [SerializeField] GameObject canvas;

    Controller controller;

    private void Awake() {
        controller = GetComponent<Controller>();
    }


    public GameObject CreateInven(int width, int height)
    {
        GameObject inven = Instantiate(invenPrefabs);

        inven.transform.Find("BotArea").GetComponent<InventoryBotArea>().gridSizeWidth = width;
        inven.transform.Find("BotArea").GetComponent<InventoryBotArea>().gridSizeHeight = height;
        inven.transform.SetParent(canvas.transform);

        Vector2 pos = inven.transform.localPosition;
        pos.x = UnityEngine.Random.Range(-800f, 300f);
        pos.y = UnityEngine.Random.Range(-100f, 500f);

        inven.transform.localPosition = pos;
        return inven;
    }

    public void InteractItem(GameObject itemObject)
    {
        Item item = itemObject.GetComponent<Item>();
        GameObject botArea = controller.MainInventory.transform.Find("BotArea").gameObject;

        for (int x = 0; x < botArea.GetComponent<InventoryBotArea>().gridSizeWidth; x++)
        {
            for (int y = 0; y < botArea.GetComponent<InventoryBotArea>().gridSizeHeight; y++)
            {
                if (botArea.transform.Find("ItemGrid").GetComponent<ItemGrid>().CheckedAvailableSpace(x, y, item.itemData.imageWidth, item.itemData.imageHeight) == true)
                {// 사용 가능 공간이 존재 한다면
                    botArea.transform.Find("ItemGrid").GetComponent<ItemGrid>().PlaceItem(item, x, y); // 적재
                    return;
                }
            }
        }

        botArea = controller.SubInventory.transform.Find("BotArea").gameObject;

        for (int x = 0; x < botArea.GetComponent<InventoryBotArea>().gridSizeWidth; x++)
        {
            for (int y = 0; y < botArea.GetComponent<InventoryBotArea>().gridSizeHeight; y++)
            {
                if (botArea.transform.Find("ItemGrid").GetComponent<ItemGrid>().CheckedAvailableSpace(x, y, item.itemData.imageWidth, item.itemData.imageHeight) == true)
                {// 사용 가능 공간이 존재 한다면
                    botArea.transform.Find("ItemGrid").GetComponent<ItemGrid>().PlaceItem(item, x, y); // 적재
                    return;
                }
            }
        }

        Debug.Log("인벤토리에 공간이 없음");

    }
}
