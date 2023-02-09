using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class LobbyGameUi : MonoBehaviour
{
    [SerializeField] InputField _text;
    [SerializeField] Charactercontroller _Character;

    public void OnChangeValue()
    {
        //Debug.Log($" field value : {_text.text}");
        _Character.SetHeroName(_text.text);
    }
}
