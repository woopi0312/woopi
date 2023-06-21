using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    public GameObject _name;
    public Text[] _slotText;
    public Text _playerName;

    bool[] _savefile = new bool[3];
    
    void Start()
    {
        for(int i = 0; i< 3; i++)
        {
            if(File.Exists(DataManager.instance.path+ $"{i}"))
            {
                _savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                _slotText[i].text = DataManager.instance.nowPlayer.name;
            }
            else
            {
                _slotText[i].text = "비어있음";
            }
        }
        DataManager.instance.DataClear();
        
    }
    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;

        if (_savefile[number] ) 
        {
            DataManager.instance.LoadData();
            toGame();
        }
        else
        {
            nameWrite();
        }        
    }

    public void nameWrite()
    {
        _name.gameObject.SetActive(true);
    }

    public void toGame()
    {
        if (!_savefile[DataManager.instance.nowSlot])
        {
            DataManager.instance.nowPlayer.name = _playerName.text;
            DataManager.instance.SaveData();//
        }
        SceneManager.LoadScene("Main");
    }

    public void gameExit()
    {
        Application.Quit();
    }
}
