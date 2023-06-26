using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] GameObject _OptionPanel;
    [SerializeField] GameObject _OptionButton;
    [SerializeField] Charactercontroller _Character;
    [SerializeField] PlayerMove _player;
    [SerializeField] Text _textName;
    [SerializeField] InputField _text;

    public Text _name;
    //public Text _time;
    //public Text _position;
    //public Text _hp;

    void Start()
    {
        _name.text += DataManager.instance.nowPlayer.name;
        //_time.text += DataManager.instance.nowPlayer.time.ToString();
        //_position.text += DataManager.instance.nowPlayer.position;
        //_hp.text += DataManager.instance.nowPlayer.hp.ToString();
        Position();
        TimeUp();
        HpDown();
    }

    public void OnButtonToLobby()
    {
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1;
    }
    
    public void OnButtonReGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    public void OnButtonOpenOption()
    {
        _OptionPanel.SetActive(true);
        _OptionButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void OnButtonExit()
    {
        _OptionPanel.SetActive(false);
        _OptionButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void OnChangeValue()
    {
        //Debug.Log($" field value : {_text.text}");
        _Character.SetHeroName(_text.text);
    }

    public void SetChangeName(string name)
    {
        _textName.text = name;
    }

    public void TimeUp()
    {
        RemainTime._rTime=DataManager.instance.nowPlayer.time;
        //DataManager.instance.nowPlayer.time++;
        //_time.text = "시간은 : " + DataManager.instance.nowPlayer.time.ToString();
    }

    public void HpDown()
    {
        PlayerMove._hp=DataManager.instance.nowPlayer.hp;
        //DataManager.instance.nowPlayer.hp--;
        //_hp.text = "체력 : " + DataManager.instance.nowPlayer.hp.ToString();
    }


    public void Save()
    {
        DataManager.instance.nowPlayer.position = _player.transform.position;
        DataManager.instance.nowPlayer.time = RemainTime._rTime;
        DataManager.instance.nowPlayer.hp = PlayerMove._hp;
        DataManager.instance.SaveData();
    }

    public void Position()
    {
        _player.transform.position = DataManager.instance.nowPlayer.position;
    }  
}
