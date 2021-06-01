using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;

    int timeElapsed;

    private void Start()
    {
        timeElapsed = 0;
        InvokeRepeating("UpdateTimer", 1, 1);
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("time", timeElapsed);
    }

    void UpdateTimer()
    {
        timeElapsed++;
        string timeString = (timeElapsed / 60).ToString("00");
        timeString += ":";
        timeString += (timeElapsed % 60).ToString("00");
        timerText.text = timeString;
    }
}
