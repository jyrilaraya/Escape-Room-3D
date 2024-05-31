using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public string sceneLOAD;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)  // Adjusted condition to include equality check
        {
            remainingTime = 0;
            scenetoload(sceneLOAD); // Replace "NextSceneName" with the name of your next scene
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);  // Changed division factor from 300 to 60
        int seconds = Mathf.FloorToInt(remainingTime % 60);  // Corrected modulo operation

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // Corrected format string
        }
    }

    void scenetoload(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}