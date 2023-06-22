using UnityEngine;

public class TrapMovingPlatform : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float _speed;
    float _time;
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

    private void Update()
    {
       if(_time +1<Time.realtimeSinceStartup)
        {
            _speed = 1;
        }
    }
    public void speedUP()
    {
        _speed = 10;
        _time = Time.realtimeSinceStartup;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.transform.CompareTag("Player"))
        //{
        //    collision.transform.SetParent(transform);         
        //}
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.transform.CompareTag("Player"))
        //{
        //    collision.transform.SetParent(null);
        //    _speed = 1;
        //}
    }
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * _speed);
        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }
}

