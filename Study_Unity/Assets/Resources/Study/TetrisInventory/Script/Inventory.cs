using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Vector3 position;
    
    private bool isOpen = true;


    public Vector3 Position{
        get => position;
        set => position = value;
    }

    public bool IsOpen{
        get => isOpen;
    }

    public void InventoryOpen(){
        position = new Vector3(position.x,position.y,0);
        GetComponent<RectTransform>().position = position;
        // transform.position = new Vector3(300, 300, 0); ;
        isOpen = true;
    }

    public void InventoryClose(){
        GetComponent<RectTransform>().position = new Vector3(2500, 500, 0);
        isOpen = false;
    }
}
