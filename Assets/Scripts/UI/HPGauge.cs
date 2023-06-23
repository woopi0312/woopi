using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    public GameObject _HPGauge;
    public GameObject _HPGauge2;
    public GameObject _HPGauge3;
    public GameObject _HPGauge4;
    Text _starText;
    private void Start()
    {
        _starText = GetComponentInChildren<Text>();
    }
    void Update()
    {
        if (PlayerMove._hp==3)
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
        if(Charactercontroller._starCount==0) 
        {
            _starText.text = "0";
        }
        if (Charactercontroller._starCount == 1)
        {
            _starText.text = "1";
        }
        if (Charactercontroller._starCount == 2)
        {
            _starText.text = "2";
        }
    }

    
    
}
