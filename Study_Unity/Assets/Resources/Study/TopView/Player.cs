using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Animator anim;
    Vector3 inputPos;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        dir = inputPos - transform.position;


        if(dir != Vector2.zero){
            anim.SetBool("isMove",true);
        }
        else{
            anim.SetBool("isMove",false);
        }

        anim.SetFloat("inputX", dir.x);
        anim.SetFloat("inputY", dir.y);

        // Vector2.MoveTowards(transform.position,inputPos,Time.deltaTime * moveSpeed);
        transform.Translate(new Vector2(dir.x, dir.y) * Time.deltaTime * moveSpeed);

        // transform.Translate(new Vector2(inputX,inputY) * Time.deltaTime * moveSpeed);
    }
}
