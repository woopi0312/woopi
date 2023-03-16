using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugMove : MonoBehaviour
{
    [SerializeField] Transform[] _points; 
    Rigidbody2D _rigid;
    public int _nextMove = 0;
    public SpriteRenderer rend;
    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
        if (_points.Length == 0) return;
        transform.Translate((_points[_nextMove].position - transform.position).normalized*Time.deltaTime * 1f);
        
        if (0.1f > Vector3.Distance(_points[_nextMove].position ,transform.position))
        {
            _nextMove++;
            rend.flipX = true;
            if (_nextMove >=_points.Length)
            {
                _nextMove = 0;
                rend.flipX = false;
            }
        }
    }
}
