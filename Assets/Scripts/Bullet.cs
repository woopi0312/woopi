using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Transform _target = null;
    Vector3 _dir;

    public void Init(Transform target)
    {
        _target = target;
        _dir = (_target.position - transform.position).normalized;
    }

    public void Init(Vector3 dir)
    {
        _dir = dir;
    }

    void Update()
    {
        transform.Translate(_dir * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            //int attack = collision.gameObject.GetComponent<rabbits>().getAttack();
            //onHitted(attack); 
            collision.gameObject.GetComponent<Charactercontroller>().hitted();
        }
    }
    
}
