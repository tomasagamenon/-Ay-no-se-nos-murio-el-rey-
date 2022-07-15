using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string _gameVersion = "0.0.0";
    public string GameVersion { get { return _gameVersion; } }
    public string _nickName = "Kodak";
    public string NickName 
    { 
        get
        {
            int value = Random.Range(0, 9999);
            string valueString;
            if (value < 10)
                valueString = "000" + value.ToString();
            else if (value < 100)
                valueString = "00" + value.ToString();
            else if (value < 1000)
                valueString = "0" + value.ToString();
            else valueString = value.ToString();
            return _nickName + "#" + valueString;
        }
    }
}
