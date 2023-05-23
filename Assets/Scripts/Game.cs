using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text _name;
    public Text _time;
    public Text _position;
    public Text _hp;
    
    void Start()
    {
        _name.text += DataManager.instance.nowPlayer.name;
        _time.text += DataManager.instance.nowPlayer.time.ToString();
        _position.text += DataManager.instance.nowPlayer.position;
        _hp.text += DataManager.instance.nowPlayer.hp.ToString();


    }

    public void TimeUp()
    {
        DataManager.instance.nowPlayer.time++;
        _time.text = "시간은 : " + DataManager.instance.nowPlayer.time.ToString();
    }

    public void HpDown()
    {
        DataManager.instance.nowPlayer.hp--;
        _hp.text = "체력 : " + DataManager.instance.nowPlayer.hp.ToString();
    }


    public void Save()
    {
        DataManager.instance.SaveData();
    }
}
