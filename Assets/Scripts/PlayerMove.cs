using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed;
    bool isGround = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        bool isMove = false;
        //bool israbbits = false;
        if (Input.GetKey("d"))
        {
            isMove = true;         
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
        }
        if (Input.GetKey("s"))
        {
            isMove = true;         
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
        }
        if (Input.GetKey("a"))
        {
            isMove = true;     
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
           

        }
        
        
        
    }
}
