using UnityEngine;

public class SlugMove : MonoBehaviour
{
    [SerializeField] Transform[] _points; 
    public int _nextMove = 0;
    public SpriteRenderer rend;
    
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
