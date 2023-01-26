using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EMoveType
{
    idle = 0,
    right = 1,
    down = 2,
    hurt = 3,
    jump = 4,
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
    bool _isHitted = false;
    GameObject _bullet;


    public SpriteRenderer rend;

    void Start()
    {
        _rab = gameObject.GetComponent<Animator>();
        Application.targetFrameRate = 30;
        rend = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (_isGameOver) return;
        move();
    }

    void move()
    {
        bool isMove = false;
        //bool israbbits = false;
        if (Input.GetKey("d"))
        {
            isMove = true;
            //israbbits = false;
            _rab.SetInteger("player", (int)EMoveType.right);
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
            rend.flipX = false;
        }
        if (Input.GetKey("s"))
        {
            isMove= true;
            //israbbits = false;
            _rab.SetInteger("player", (int)EMoveType.down);
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
        }
        if (Input.GetKey("a"))
        {
            isMove= true;
            //v2 += Vector2.left * Time.deltaTime * _speed;
            //israbbits = false;
            _rab.SetInteger("player", (int)EMoveType.right);
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            rend.flipX = true;
           
        }
        if(!isGround) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMove= true;
            _rab.SetInteger("player", (int)EMoveType.jump);
            transform.Translate(Vector3.up );
            isGround = false;
        }
        if (!isMove)
        {
            
            _rab.SetInteger("player", 0);
        }

        //else if(v2 != Vector3.zero)
        //{
        //    _rab.SetInteger("player", 0);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "Bullet2D")
        {
            //ResetPosition();
            _rab.SetInteger("player", 3);
            _isHitted = true;
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
