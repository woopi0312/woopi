using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum EMoveType
{
    idle = 0,
    right = 1,
    down = 2,
    hurt = 3,
    jump = 4,
    climb = 5,
}

public class Charactercontroller : MonoBehaviour
{
     Rigidbody2D myrigidbody;
    
    [SerializeField] float _speed;
    [SerializeField] int _attack;
    [SerializeField] int _hp;
    [SerializeField] GameUi _gameUi;
    [SerializeField] GameObject _uiPanel;
    
    Animator _rab;

    bool isGround = false;
    bool _isGameOver = false;
    bool _isHitted = false;
    public bool isLadder = false;
    GameObject _bullet;
    string _heroName;

    public SpriteRenderer rend;

    void Start()
    {
        _rab = gameObject.GetComponent<Animator>();
        Application.targetFrameRate = 30;
        rend = GetComponent<SpriteRenderer>();
        myrigidbody=GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (_isGameOver) return;
        move();

        if (isLadder == true)
        {
            float ver = Input.GetAxis("Vertical");

            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, ver * _speed);
            _rab.SetInteger("player", (int)EMoveType.climb);
        }
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
            //transform.Translate(Vector3.up );
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300);
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
            ResetPosition();
            _rab.SetInteger("player",3);
            _isHitted = true;
        }
        if(collision.gameObject.tag == "Trap")
        {
            ResetPosition();
        }
        if(collision.gameObject.tag == "Slug")
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
            _uiPanel.SetActive(true);
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

    public void SetHeroName(string _name)
    {
        _heroName = _name;
        _gameUi.SetChangeName(_heroName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
            Debug.Log("true");
            myrigidbody.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            Debug.Log("false");
            myrigidbody.gravityScale = 1;
        }
    }
}

