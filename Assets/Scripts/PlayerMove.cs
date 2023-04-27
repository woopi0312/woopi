using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    [SerializeField] float _speed;
    public bool _isLadder = false;
    bool _isGround = false;
   

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
        if (!_isGround) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //isMove = true;
            //_rab.SetInteger("player", (int)EMoveType.jump);
            //transform.Translate(Vector3.up);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 250);
            _isGround = false;
        }

    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGround = true;
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
