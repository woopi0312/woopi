using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] float _speed;
    public float _distance;
    public float _teldistance;
    public float _jumpPower;
    Transform _player;
    public LayerMask groundLayer;
    Rigidbody2D rig;
    public SpriteRenderer rend;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("PlayerBase").transform;
        Physics2D.IgnoreLayerCollision(9, 7);
    }

    
    void Update()
    {
        if(Mathf.Abs(transform.position.x - _player.position.x) >_distance) 
        { 
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * _speed);
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * -1f,0.5f,groundLayer);

            RaycastHit2D hitdia =Physics2D.Raycast(transform.position, new Vector2(1 * DirectionBear(), 1), 2f,groundLayer);
            if (_player.position.y - transform.position.y <= 0)
            hitdia = new RaycastHit2D();
            if (hit || hitdia)
            {
                // rig.velocity = Vector2.up * _jumpPower;
            }

            //if (Vector2.Distance(_player.position, transform.position) > _teldistance) 텔레포트
            //{
            //    transform.position = (_player.position );
                
            //}
           
        }

    }
        //public ParticleSystem _tel;

    float DirectionBear()
    {
        if(transform.position.x - _player.position.x <0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rend.flipX = true;
            return 1;
        }
        else 
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            
            return -1;
        }
    }

}
