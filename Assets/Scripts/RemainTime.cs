using UnityEngine;
using UnityEngine.UI;
public class RemainTime : MonoBehaviour
{
    Text text;
    public static float _rTime = 100f;
    void Start()
    {
        text= GetComponent<Text>();       
    }

   
    void Update()
    {        
        _rTime -= Time.deltaTime;
        if (_rTime < 0)
            _rTime = 0;
        text.text= "Remain Time : "+Mathf.Round(_rTime); ;       
    }
}
