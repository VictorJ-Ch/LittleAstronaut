 using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    void Start()
    {
        instance = this;
        
    }
    void Update()
    {
        
    }
    public void SavingData()
    {
        SaveScore highScoreSave = new SaveScore(PlayerPrefs.GetFloat("HighScore"));

        string json = JsonUtility.ToJson(highScoreSave, true);

        string ruteArray = Application.streamingAssetsPath + "/highScore.json";
        File.WriteAllText(ruteArray, json);
    }

}
