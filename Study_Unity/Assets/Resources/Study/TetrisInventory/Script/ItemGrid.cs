using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    Inventory inventory;
    Item[,] itemSlot;
    GameObject botArea;
    GameObject topArea;
    RectTransform rectTransform;

    public const float tileSizeWidth = 32;
    public const float tileSizeHeight = 32;

    private int gridSizeWidth;
    private int gridSizeHeight;

    Vector2 positionOnGrid = new Vector2();
    Vector2Int tileGridPosition = new Vector2Int();

    private void Start() {
        rectTransform = GetComponent<RectTransform>();

        inventory = transform.parent.parent.GetComponent<Inventory>();
        botArea = inventory.transform.Find("BotArea").gameObject;
        topArea = inventory.transform.Find("TopArea").gameObject;

        gridSizeWidth = botArea.GetComponent<InventoryBotArea>().gridSizeWidth;
        gridSizeHeight = botArea.GetComponent<InventoryBotArea>().gridSizeHeight;

        Init(gridSizeWidth,gridSizeHeight);
    }

    private void Init(int width, int height){
        itemSlot = new Item[width,height];

        Vector2 size = new Vector2(width * tileSizeWidth, height * tileSizeHeight);
        rectTransform.sizeDelta = size;

        botArea.GetComponent<RectTransform>().sizeDelta = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
        topArea.GetComponent<RectTransform>().sizeDelta = new Vector2(rectTransform.rect.width, 100);
        inventory.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
    }

    public bool CheckedAvailableSpace(int posX, int posY, int width, int height)    // 사용 가능 공간 체크
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (itemSlot[posX + x, posY + y] != null)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void PlaceItem(Item item, int posX, int posY)    // 인벤토리에 아이템 적재
    {
        RectTransform rectTransform = item.GetComponent<RectTransform>();

        rectTransform.SetParent(this.rectTransform);

        for (int x = 0; x < item.itemData.imageWidth; x++)
        {
            for (int y = 0; y < item.itemData.imageHeight; y++)
            {
                itemSlot[posX + x, posY + y] = item;

            }
        }

        item.onPositionX = posX;
        item.onPositionY = posY;

        Vector2 position = CalculatePositionOnGrid(item, posX, posY);
        rectTransform.localPosition = position;
    }

    public void CleanGridReference(Item item)//인벤토리 지정 아이템 영역 비우기
    {
        for (int ix = 0; ix < item.itemData.imageWidth; ix++)
        {
            for (int iy = 0; iy < item.itemData.imageHeight; iy++)
            {
                itemSlot[item.onPositionX + ix, item.onPositionY + iy] = null;
            }
        }
    }

    public Vector2 CalculatePositionOnGrid(Item item, int posX, int posY)   // 그리드에 적용시킬 영역 계산
    {
        Vector2 position = new Vector2();
        position.x = posX * tileSizeWidth + tileSizeWidth * item.itemData.imageWidth / 2;
        position.y = -(posY * tileSizeHeight + tileSizeHeight * item.itemData.imageHeight / 2);
        return position;

    }

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    { // 마우스 위치에서 그리드 위치 추출

        positionOnGrid.x = mousePosition.x - rectTransform.position.x;
        positionOnGrid.y = rectTransform.position.y - mousePosition.y;

        tileGridPosition.x = (int)(positionOnGrid.x / tileSizeWidth);
        tileGridPosition.y = (int)(positionOnGrid.y / tileSizeHeight);

        return tileGridPosition;
    }

}
