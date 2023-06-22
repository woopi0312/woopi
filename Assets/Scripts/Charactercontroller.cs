using UnityEngine;
using UnityEngine.Tilemaps;

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
    [SerializeField] Rigidbody2D myrigidbody;
    [SerializeField] Transform _base;
    [SerializeField] int _attack;
    [SerializeField] int _hp;
    [SerializeField] GameUi _gameUi;

    [SerializeField] GameObject _clearPanel;
    [SerializeField] GameObject _deathPanel;
    [SerializeField] GameObject _cage;
    [SerializeField] Bear _bear;
    float _maxHP = 3;

    Animator _rab;

    bool _isGround = false;
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
        
    }


    void Update()
    {
        if (_isGameOver) return;
        move();

        if (isLadder == true)
        {
            //float ver = Input.GetAxis("Vertical");

            //myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, ver * _speed);
            _rab.SetInteger("player", (int)EMoveType.climb);
        }
    }

    void move()
    {
        bool isMove = false;       
        if (Input.GetKey("d"))
        {
            isMove = true;        
            _rab.SetInteger("player", (int)EMoveType.right);         
            rend.flipX = false;
        }
        if (Input.GetKey("s"))
        {
            isMove= true;         
            _rab.SetInteger("player", (int)EMoveType.down);          
        }
        if (Input.GetKey("a"))
        {
            isMove= true;         
            _rab.SetInteger("player", (int)EMoveType.right);        
            rend.flipX = true;
           
        }
        if (!_isGround) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMove = true;
            _rab.SetInteger("player", (int)EMoveType.jump);                       
            _isGround = false;
        }
        if (!isMove)
        {
            
            _rab.SetInteger("player", 0);
        }      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            _isGround = true;
        }
        if(collision.gameObject.tag == "Bullet2D")
        {
            //ResetPosition();
            _rab.SetInteger("player",3);
            _isHitted = true;
        }
        if(collision.gameObject.tag == "Trap")
        {
            _isGameOver = true;
            _deathPanel.SetActive(true);
            _rab.SetInteger("player", (int)EMoveType.jump);
            Time.timeScale = 0;

        }
        if(collision.gameObject.tag == "Slug")
        {
            ResetPosition();
        }
        if(collision.gameObject.tag == "Goal")
        {
            _isGameOver = true;
            _clearPanel.SetActive(true);
            _rab.SetInteger("player", (int)EMoveType.jump);
            Time.timeScale=0;
        }
        if(collision.gameObject.tag== "Monster")
        {
            Debug.Log("Ãæµ¹Çß½À´Ï´Ù");
            hitted();
        }
    }
    public void hitted()
    {
        if (_hp < 0) return;
        if (rend.flipX == false)
        {
            myrigidbody.AddForce(new Vector2(-5, 1), ForceMode2D.Impulse);
        }
        if (rend.flipX == true) 
        {
            myrigidbody.AddForce(new Vector2(5, 1), ForceMode2D.Impulse);
        }
        _rab.SetInteger("player", 3);
    }
    public int getAttack()
    {
        return _attack;
    }

    private void ResetPosition()
    {
        _base.position = new Vector3(0f,0f,0);
    }

    public void SetHeroName(string _name)
    {
        _heroName = _name;
        _gameUi.SetChangeName(_heroName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        if (collision.gameObject.tag == "Event")
        {
            Debug.Log("ºÎµúÈû");
            _bear.setOpenCage();
            _cage.GetComponent<TilemapCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;          
        }
    }
}

