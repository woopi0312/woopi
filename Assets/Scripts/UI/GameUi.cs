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
    [SerializeField] Text _textName;
    [SerializeField] InputField _text;
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
}
