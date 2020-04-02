using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;

public class GameOptionsLoader : MonoBehaviour
{
    string _localPath = "ultimateGameOptions.xml";

    private void Start()
    {
        Debug.Log("En el player prefs:" + PlayerPrefs.GetString("PlayerName", "Jhon Doe"));
        LoadGameOptions();
    }
    public void SaveGameOptions()
    {
        using (Stream fileStream = new FileStream(Application.persistentDataPath + "\\" + _localPath, FileMode.Create))
        {
            DataContractSerializer dataContract = new DataContractSerializer(typeof(GameOptions));
            dataContract.WriteObject(fileStream, GameOptions.Instance);
        }
    }

    public void LoadGameOptions()
    {
        using (Stream fileStream = new FileStream(Application.persistentDataPath + "\\" + _localPath, FileMode.Open))
        {
            DataContractSerializer dataContract = new DataContractSerializer(typeof(GameOptions));
            GameOptions.Instance = (GameOptions)dataContract.ReadObject(fileStream);

        }
    }
}
