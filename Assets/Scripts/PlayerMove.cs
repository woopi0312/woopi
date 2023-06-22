using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    AudioSource _audioSource;
    [SerializeField] float _speed;
    [SerializeField] GameObject _uiPanel;
    public AudioClip jumpAudio;
    public AudioClip moveAudio;
    public static int _hp = 3;
    public bool _isLadder = false;
    bool _isGround = false;
    bool _isGameOver = false;

    float _timecheck=0;
    float _time = 0;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        myrigidbody = GetComponent<Rigidbody2D>();      
    }

    private void Update()
    {
        //_timecheck += Time.deltaTime;
        //if (_timecheck>=1 )
        //{
        //    _time += 1;
        //    Debug.Log("시간" + _time);
        //    _timecheck = 0;
        //}
        _isGround = false;
        Debug.DrawRay(transform.position - transform.up * 0.5f, -transform.up*0.7f,Color.red,2);
        RaycastHit2D hit = Physics2D.Raycast(transform.position- transform.up * 0.5f, -transform.up, 0.7f, 1 << LayerMask.NameToLayer("MovingPlatForm"));
        if(hit)
        {
            hit.collider.GetComponent<TrapMovingPlatform>().speedUP();
        }
        if (Physics2D.Raycast(transform.position - Vector3.right*0.3f, -transform.up,  0.7f, 1 << LayerMask.NameToLayer("Ground")))
        {          
            _isGround = true;
        }
        if (Physics2D.Raycast(transform.position + Vector3.right*0.3f, -transform.up, 0.7f, 1 << LayerMask.NameToLayer("Ground")))
        {
            _isGround = true;
        }
        if (!_isGround && GetComponent<FixedJoint2D>() == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //isMove = true;
            //_rab.SetInteger("player", (int)EMoveType.jump);
            //transform.Translate(Vector3.up);
            if (transform.GetComponent<FixedJoint2D>() != null)
            {
                Destroy(GetComponent<FixedJoint2D>());
                _timecheck = Time.realtimeSinceStartup;
            }
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5, ForceMode2D.Impulse);
            //_isGround = false;
            PlaySound("Jump");
        }
    }
    public void addFixedJoint(GameObject _basket)
    { 
        if (_timecheck + 0.5 <= Time.realtimeSinceStartup)
        {
            if (transform.GetComponent<FixedJoint2D>() == null)
            {
                FixedJoint2D _fixedjoint2d = transform.AddComponent<FixedJoint2D>();
                _fixedjoint2d.connectedBody = _basket.GetComponent<Rigidbody2D>();
                _fixedjoint2d.autoConfigureConnectedAnchor = false;
            }          
        }
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
            _speed = 3;
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
            //PlaySound("Move");
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
    float _lasttime;
    void PlaySound(string action)
    {
        switch(action)
        {
            case "Move":
                if(_lasttime+0.4>=Time.realtimeSinceStartup)
                {
                    return;
                }
                _audioSource.clip = moveAudio;
                _lasttime = Time.realtimeSinceStartup;
                break;
            case "Jump":
                _audioSource.clip = jumpAudio;
                break;
        }
        _audioSource.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground") && collision.contacts[0].normal.y>=0.45)
        //{
        //    _isGround = true;
        //}
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
