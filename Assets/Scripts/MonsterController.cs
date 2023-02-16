using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] Transform Player;
    GameObject _monster;
    List<Monster> mons = new List<Monster>();
    void Start()
    {
        
    }

    void makeMonsters()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject mon = Instantiate(_monster, transform);
            mons.Add(mon.GetComponent<Monster>());
            // 1. array Instantiate(_monster, transform);
        }
        foreach (Monster mon in mons)
        {
            mon.Init(this, Player);
        }
        
    }

    public Transform selectMonster()
    {
        float distance = 0f;
        Transform target = null;
        foreach (Monster mon in mons)
        {
            if (distance > Vector3.Distance(mon.transform.position, Player.position) || target == null)
            {
                distance = Vector3.Distance(mon.transform.position, Player.position);
                target = mon.transform;
            }
        }
        return target;
    }

    void Update()
    {
        
    }
}
