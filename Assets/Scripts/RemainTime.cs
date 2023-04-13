using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RemainTime : MonoBehaviour
{
    Text text;
    public static float _rTime = 0f;
    void Start()
    {
        text= GetComponent<Text>();
    }

   
    void Update()
    {
        _rTime += Time.deltaTime;
        if (_rTime < 0)
            _rTime = 0;
        text.text= "Remain Time : "+Mathf.Round(_rTime); ;
    }
}
