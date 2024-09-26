 using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    void Start()
    {
        /*
        //Save data
        PlayerPrefs.SetInt("Age", 32);
        // Obtain
        int age = PlayerPrefs.GetInt("Age");
        print(age);
        */
        // string rute = Application.dataPath + "/StreamingAssets/heroClass.json";
        //2nd other
        /*
        HeroClass goku = new HeroClass("Goku", 20, 20, 2);

        print(goku.life);

        string json = JsonUtility.ToJson(goku, true);
        print (json);
        */

        //3rd other
        /*
        string json = File.ReadAllText(rute);

        HeroClass hero = JsonUtility.FromJson<HeroClass>(json);
        print(hero.name);
        hero.name = "Gohan";
        print(hero.name);

        
        File.WriteAllText(rute, json);
        */
        instance = this;
        
    }
    void Update()
    {
        
    }
    public void SavingData()
    {
        SaveScore highScoreSave = new SaveScore(PlayerPrefs.GetFloat("HighScore"));

        string json = JsonUtility.ToJson(highScoreSave, true);
        //string json = JsonHelper.ToJson(highScoreSave, true);

        string ruteArray = Application.streamingAssetsPath + "/highScore.json";
        File.WriteAllText(ruteArray, json);
    }

}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
