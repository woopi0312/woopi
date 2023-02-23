using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterController _mc;
    Transform Player;
    float _speed;
    float _runtimer = 0f;
    int _hp;
    bool isRun = false;
    bool isLive = false;
    bool isHitted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(MonsterController mc, Transform player)
    {
        gameObject.SetActive(true);
        Player = player ;
        _mc = mc;
        _speed = 2;
        _hp = 30;
        //HpChange(_hp / _maxHp);
        Vector3 ramPos = player.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 6;
        transform.position = ramPos;
        Debug.Log("몬스터 초기화를 호출합니다.");
        isLive = true;
    }

    public int getHP()
    {
        return _hp;

    }
    void Update()
    {
        if (isLive) move();
        runCheck();
    }

    void move()
    {
        
        if (isRun)
            transform.position += (transform.position - Player.position).normalized * Time.deltaTime * _speed;
        else
            transform.position -= (transform.position - Player.position).normalized * Time.deltaTime * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //int attack = collision.gameObject.GetComponent<rabbits>().getAttack();
            //onHitted(attack); 
            collision.gameObject.GetComponent<Charactercontroller>().hitted();
        }
        if (collision.gameObject.name == "Bullet")
        {
            onHitted(15);
            collision.gameObject.GetComponent<BulletRemove>().Remove();
        }
        if (collision.gameObject.GetComponent<Damage>() != null)
        {
            int damage = collision.gameObject.GetComponent<Damage>().getDamage();
            collision.gameObject.GetComponent<BulletRemove>().Remove();
            onHitted(damage);
        }
    }

    void onHitted(int hitPower)
    {
        _hp -= hitPower;
        isHitted = true;
        isRun = true;
        if (_hp < 0)
        {
            isLive = false;
        }
        
    }

    void runCheck()
    {
        if (isRun)
        {
            _runtimer += Time.deltaTime;
            if (_runtimer > 0.5f)
            {
                isRun = false;
                _runtimer = 0f;
            }
        }
    }
}
