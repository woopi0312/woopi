using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    //이름 체력 위치 남은시간. 
    public string name;
    public int hp=3;
    public Vector2 position=new Vector2(-7,-1.7f);
    public float time=100;
}

public class DataManager : MonoBehaviour
{
    //싱글톤
    public static DataManager instance;

    public PlayerData nowPlayer = new PlayerData();

    public string path;
    public int nowSlot;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/save";
        Debug.Log(Application.persistentDataPath);
    }
    void Start()
    {
        //SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), data);//
    }
    
    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
