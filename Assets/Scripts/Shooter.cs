using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _deg;
    [SerializeField] float _gap;
    [SerializeField] int _count;
    [SerializeField] Transform _target;
    AudioSource _audioSource;
    void Start()
    {
        StartCoroutine(CoInfiniteMultiShot());
        _audioSource = GetComponent<AudioSource>();
    }

    IEnumerator CoInfiniteMultiShot()
    {
        while (true)
        {
            Vector3 v3temp = _target.position - transform.position;
            float degTemp = Mathf.Atan2(v3temp.y, v3temp.x);
            float radDeg = degTemp * Mathf.Deg2Rad;
            for (int i = 0; i < _count; i++)
            {
                GameObject temp = Instantiate(_bullet);
                temp.transform.position = transform.position;
                float deg = i * (_deg / (_count - 1)) + radDeg - _deg / 2f;
                Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad + degTemp), Mathf.Sin(deg * Mathf.Deg2Rad + degTemp), 0);
                temp.GetComponent<Bullet>().Init(dir);
            }
            yield return new WaitForSeconds(1f);
                _audioSource.Play();
        }
    }    
}
