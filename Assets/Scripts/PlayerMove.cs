using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    [SerializeField] float _speed;
    public static int _hp = 3;
    [SerializeField] GameObject _uiPanel;
    public bool _isLadder = false;
    bool _isGround = false;
    bool _isGameOver = false;

    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();      
    }
    void FixedUpdate()
    {
        move();
        if (_isLadder == true)
        {
            float ver = Input.GetAxis("Vertical");

            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, ver * _speed);           
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            _speed = 1;
        }
        if(Input.GetKeyUp(KeyCode.C)) 
        {
            _speed = 5;
        }
    }

    public void move()
    {
        //bool isMove = false;
        //bool israbbits = false;
        if (Input.GetKey("d"))
        {
            //isMove = true;         
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
        }
        if (Input.GetKey("s"))
        {
            //isMove = true;         
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
        }
        if (Input.GetKey("a"))
        {
            //isMove = true;     
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }
        if (!_isGround && GetComponent<FixedJoint2D>() == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //isMove = true;
            //_rab.SetInteger("player", (int)EMoveType.jump);
            //transform.Translate(Vector3.up);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 250);
            if (GetComponent<FixedJoint2D>()!=null)
            { 
                Destroy(GetComponent<FixedJoint2D>());
            }
                _isGround = false;
            
        }

    }

    public void hitted()
    {
        if (_hp < 0) return;
        _hp--;
        if (_hp <= 0)
        {
            _isGameOver = true;
            _uiPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("충돌했습니다");
            hitted();
        }
        if (collision.gameObject.tag == "Bullet2D")
        {           
            hitted();
            Debug.Log("총알에 맞았습니다");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            _isLadder = true;
            myrigidbody.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            _isLadder = false;
            myrigidbody.gravityScale = 1;
        }
    }
}
