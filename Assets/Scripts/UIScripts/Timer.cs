using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 using System;
using System.IO;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameObject gameOverGroup;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject startNotification;
    public GameObject newRecordNotification;
    public Animator startAnimator;
    public Animator newRecordAnimator;
    public float startNotificationDelay = 5.0f;
    public float newRecordNotificationDelay = 5.0f;
    float currentTime;
    float highScore;
    bool isTiming;
    bool isNewRecordPlayed = false;

    void Start()
    {
        //restartHighScore();
        currentTime = 0.0f;
        highScore = PlayerPrefs.GetFloat("HighScore", 0.0f);
        StartTimer();
    }

    void Update()
    {
        if (isTiming)
        {
            currentTime += Time.deltaTime;
            // Conversión de minutos y segundos
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            // Formato
            timer.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            if (currentTime > highScore)
            {
                highScore = currentTime;
                PlayerPrefs.SetFloat("HighScore", highScore);
                PlayerPrefs.Save();
                //------
                SaveManager.instance.SavingData();
                //------
                Debug.Log("New High Score: " + highScore.ToString("F2"));
                if (!isNewRecordPlayed)
                {
                    StartCoroutine(HandleNewRecordAnimation());
                    isNewRecordPlayed = true;
                }
            }
        }
    }

    public void StartTimer()
    {
        isTiming = true;
        currentTime = 0.0f;
        StartAnimation();
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    public void ShowGameOverGroup()
    {
        if (gameOverGroup != null)
        {
            // Score
            int scoreMinutes = Mathf.FloorToInt(currentTime / 60);
            int scoreSeconds = Mathf.FloorToInt(currentTime % 60);
            string scoreFormat = string.Format("{0:D2}:{1:D2}", scoreMinutes, scoreSeconds);
            // Best Score
            int bestScoreMinutes = Mathf.FloorToInt(highScore / 60);
            int bestScoreSeconds = Mathf.FloorToInt(highScore % 60);
            string bestScoreFormat = string.Format("{0:D2}:{1:D2}", bestScoreMinutes, bestScoreSeconds);
            // UI
            if (scoreText != null)
            {
                scoreText.text = scoreFormat;
            }
            if (bestScoreText != null)
            {
                bestScoreText.text = bestScoreFormat;
            }
            gameOverGroup.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No existe GameOverGroup");
        }
    }

    public void restartHighScore()
    {
        highScore = 0.0f;
        PlayerPrefs.SetFloat("HighScore", highScore);
        PlayerPrefs.Save();
        Debug.Log("High Score Restarted");
    }

    void StartAnimation()
    {
        startNotification.SetActive(true);
        startAnimator.Play("StartOn");
        Invoke("StartAnimationOff", startNotificationDelay);
    }

    void StartAnimationOff()
    {
        if (startAnimator != null)
        {
            startAnimator.Play("StartOff");
        }
    }

    IEnumerator HandleNewRecordAnimation()
    {
        yield return new WaitForSeconds(GetAnimationLength(startAnimator, "StartOff"));
        NewRecordAnimation();
    }
    float GetAnimationLength(Animator animator, string animationName)
    {
        if (animator != null)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName(animationName))
            {
                return stateInfo.length;
            }
        }
        return 5.0f;
    }
    void NewRecordAnimation()
    {
        if (newRecordNotification != null && newRecordAnimator != null)
        {
            newRecordNotification.SetActive(true);
            newRecordAnimator.Play("NewRecordOn");
            Invoke("NewRecordAnimationOff", newRecordNotificationDelay);
        }
    }

    void NewRecordAnimationOff()
    {
        if (newRecordAnimator != null)
        {
            newRecordAnimator.Play("NewRecordOff");
            Invoke("DisableNewRecordNotification", 5.0f);
        }
    }
    void DisableNewRecordNotification()
    {
        if(newRecordNotification != null)
        {
            newRecordNotification.SetActive(false);
        }
    }
}