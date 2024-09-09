using UnityEngine;
using TMPro;
using System;

public class DisplayHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    void Start()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0.0f);
        //Maths
        int minutes = Mathf.FloorToInt(highScore / 60);
        int seconds = Mathf.FloorToInt(highScore % 60);
        //Format
        string highScoreFormat = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        //UI
        if (highScoreText != null)
        {
            highScoreText.text = highScoreFormat;
        }
        else
        {
            Debug.LogWarning("Is missing the highScore");
        }
    }

    void Update()
    {
        
    }
}
