using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EMoveType
{
    right = 1,
    down = 2,
    left = 3,
    up = 4,
}

public class Charactercontroller : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _attack;
    [SerializeField] int _hp;
    //[SerializeField] GameObject _uiPanel;
    
    Animator _rab;

    bool isGround = false;
    bool _isGameOver = false;

    GameObject _bullet;




    void Start()
    {
        _rab = gameObject.GetComponent<Animator>();
        Application.targetFrameRate = 30;
    }


    void Update()
    {
        if (_isGameOver) return;
        move();
    }

    void move()
    {
        Vector2 v2 = Vector2.zero;
        //bool israbbits = false;
        if (Input.GetKey("d"))
        {
            v2 += Vector2.right * Time.deltaTime * _speed;
            //israbbits = false;
            _rab.SetInteger("player", (int)EMoveType.right);
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
        }
        if (Input.GetKey("s"))
        {
            v2 += Vector2.down * Time.deltaTime * _speed;
            //israbbits = false;
            _rab.SetInteger("player", (int)EMoveType.down);
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
        }
        if (Input.GetKey("a"))
        {
            v2 += Vector2.left * Time.deltaTime * _speed;
            //israbbits = false;
            _rab.SetInteger("player", (int)EMoveType.left);
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }
        if(!isGround) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up );
            isGround = false;
        }
        if (v2 != Vector2.zero)
        {
            _rab.SetInteger("idle", 0);
        }

        else
        {
            _rab.SetInteger("idle", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "Bullet2D")
        {
            ResetPosition();
        }
    }

    public void hitted()
    {
        if (_hp < 0) return;
        _hp -= 5;
        if (_hp < 0)
        {
            _isGameOver = true;
            //_uiPanel.SetActive(true);
        }
    }
    public int getAttack()
    {
        return _attack;
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(-6.2f,-2.4f,0);
    }


}

