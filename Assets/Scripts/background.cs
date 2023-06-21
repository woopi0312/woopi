using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    [SerializeField] GameObject _playebase;
    Transform _background;
    float transy=0;
    void Start()
    {
        _background = GetComponent<Transform>();
    }

    
    void Update()
    {
        //_background.transform.Translate(_playebase.transform.position);
    }
}
