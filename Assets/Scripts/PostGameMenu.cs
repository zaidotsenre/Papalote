using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostGameMenu : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text recordText;
    [SerializeField] GameObject recordImage;
    [SerializeField] GameObject recordGroup;

    private void Start()
    {
        int time = PlayerPrefs.GetInt("time");
        int record = PlayerPrefs.GetInt("record");

        timeText.text = FormatTime(time);
        
        if (time > record)
        {
            PlayerPrefs.SetInt("record", time);
            recordImage.SetActive(true);
            recordGroup.SetActive(false);
        }
        else
        {
            recordText.text = FormatTime(record);
        }
    }

    string FormatTime(int seconds)
    {
        string formattedTime;
        formattedTime = (seconds / 60).ToString("00");
        formattedTime += ":";
        formattedTime += (seconds % 60).ToString("00");
        return formattedTime;
    }
}
