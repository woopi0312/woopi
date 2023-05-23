using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPGauge : MonoBehaviour
{
    public GameObject _HPGauge;
    public GameObject _HPGauge2;
    public GameObject _HPGauge3;
    public GameObject _HPGauge4;
    void Update()
    {
        if(PlayerMove._hp==3)
        {
            _HPGauge.SetActive(true);
        }
        if(PlayerMove._hp==2)
        {
            _HPGauge.SetActive(false);
            _HPGauge2.SetActive(true);
        }
        if(PlayerMove._hp==1) 
        {       
            _HPGauge2.SetActive(false);
            _HPGauge3.SetActive(true);
        }
        if(PlayerMove._hp<=0) 
        {
            _HPGauge3.SetActive(false);
            _HPGauge4.SetActive(true);
        }
    }

    
    
}
