using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    CanvasController canvasController;
    ItemController itemController;
    PlayerController playerController;
    GameObject player;

    private GameObject mainInventory;
    private GameObject subInventory;

    List<Item> itemlist = new List<Item>();

    private void Awake() {
        canvasController = GetComponent<CanvasController>();
        itemController = GetComponent<ItemController>();
        player = GameObject.Find("Player").gameObject;
        playerController = player.GetComponent<PlayerController>();
    }

    private void Start() {
        mainInventory = canvasController.CreateInven(20,10);
        subInventory = canvasController.CreateInven(5,3);

        mainInventory.GetComponent<Inventory>().Position = mainInventory.transform.position;
        subInventory.GetComponent<Inventory>().Position = subInventory.transform.position;
        Debug.Log("Before : " + mainInventory.GetComponent<Inventory>().Position);


        mainInventory.GetComponent<Inventory>().InventoryClose();
        subInventory.GetComponent<Inventory>().InventoryClose();
        Debug.Log("After : " + mainInventory.GetComponent<Inventory>().Position);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.I)){
            if(mainInventory.GetComponent<Inventory>().IsOpen == true || subInventory.GetComponent<Inventory>().IsOpen == true){
                mainInventory.GetComponent<Inventory>().InventoryClose();
                subInventory.GetComponent<Inventory>().InventoryClose();
            }
            else{
                mainInventory.GetComponent<Inventory>().InventoryOpen();
                subInventory.GetComponent<Inventory>().InventoryOpen();
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            itemlist.Add(itemController.CreateItem());
        }
        else if(Input.GetKeyDown(KeyCode.Z)){
            playerController.ItemStore();
        }


    }

    public GameObject MainInventory{
        get => mainInventory;
    }

    public GameObject SubInventory{
        get => subInventory;
    }

    

}
