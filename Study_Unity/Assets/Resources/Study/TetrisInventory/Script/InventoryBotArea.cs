using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryBotArea : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int gridSizeWidth;
    public int gridSizeHeight;

    bool onGrid = false;

    RectTransform testRect;

    Vector2 prePosition;
    CanvasGroup canvasGroup;

    RaycastResult ray;

    ItemGrid itemGrid;

    private void Awake() {
        itemGrid = GameObject.Find("ItemGrid").GetComponent<ItemGrid>();
        testRect = itemGrid.gameObject.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ray = eventData.pointerPressRaycast;
        if(ray.gameObject.name != "ItemGrid"){
            prePosition = ray.gameObject.GetComponent<RectTransform>().position;
            canvasGroup = ray.gameObject.GetComponent<CanvasGroup>();

            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        ray = eventData.pointerPressRaycast;
        if (ray.gameObject.name != "ItemGrid"){
            
            ray.gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        ray = eventData.pointerPressRaycast;
        RaycastResult r = eventData.pointerPressRaycast;
        

        
        
        if (ray.gameObject.name != "ItemGrid"){

            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            if (onGrid == false)
            {
                ray.gameObject.GetComponent<RectTransform>().position = prePosition;
                
                return;
            }

            

            Item item = ray.gameObject.GetComponent<Item>();

            Vector2Int onGridPosition = itemGrid.GetTileGridPosition(Input.mousePosition);

            

            
            
            if(itemGrid.CheckedAvailableSpace(onGridPosition.x,onGridPosition.y,item.itemData.imageWidth,item.itemData.imageHeight)){
                itemGrid.CleanGridReference(item);
                itemGrid.PlaceItem(item,onGridPosition.x,onGridPosition.y);
            }
            else{
                ray.gameObject.GetComponent<RectTransform>().position = prePosition;
            }
            

        }
        
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        onGrid = true;
        // Debug.Log("OnGrid : " + onGrid);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
        onGrid = false;
        // Debug.Log("OnGrid : " + onGrid);
    }
}
