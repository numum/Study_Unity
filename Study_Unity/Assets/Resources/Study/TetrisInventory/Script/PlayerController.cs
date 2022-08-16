using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    [SerializeField] float runSpeed = 5.0f;

    GameObject controller;

    ItemController itemController;
    CanvasController canvasController;
    

    GameObject curInteractItem;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        controller = GameObject.Find("Controller").gameObject;
        itemController = controller.GetComponent<ItemController>();
        canvasController = controller.GetComponent<CanvasController>();

        
        
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        curInteractItem = other.gameObject;

    }

    

    public void ItemStore()
    {
        if (curInteractItem != null)
        {
            Item item = itemController.CreateItemUI(curInteractItem.GetComponent<Item>(), curInteractItem.name);

            canvasController.InteractItem(item.gameObject);
            
        }
    }
}
