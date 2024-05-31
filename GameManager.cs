using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text txtQuestUpdate;
    public Text txtInteractMsg;

    public string gameOverLevel;
    public string nextLevel;

    public string firstQuest = "find a way to stop the ticking sound...";
    public float bombTimer;

    public bool isBombFound;
    public bool isBombDisarmed;
    public bool isCRDoorUnlocked;
    public bool isCRDoorKeyCollected;
    public bool isFlashLightCollected;
    public bool isScissorsFound;
    public bool isBatteryCollected;

    //these variables are for opening the door
    public string correctKeyCode;
    public string keyCode;
    public InputField code;

    // Start is called before the first frame update
    void Start()
    {
        if (txtInteractMsg != null)
        {
            txtInteractMsg.text = "What happened? I don't feel good, \n What is that sound, Make it stop!";
        }
        Invoke("Show1stMission", 2.5f);
    }
    void Show1stMission()
    {

        if (txtInteractMsg != null)
        {
            txtInteractMsg.text = "";
        }

        if (txtQuestUpdate != null)
        {
            txtQuestUpdate.text = "Find the source of the sound and stop it.";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isBombDisarmed)
        {
            bombTimer -= Time.deltaTime;
            if (isBombFound)
            {
                BombQuest();
            }
            if (bombTimer <= 0)
            {
                Debug.Log("The bomb exploded");
                SceneManager.LoadScene(gameOverLevel);
            }
        }
        else
        {
            if (txtQuestUpdate != null)
            {
                txtQuestUpdate.text = "Find the source of the sound and stop it.";
            }

            if (code != null)
            {
                keyCode = code.text;
                if (keyCode == correctKeyCode)
                {
                    Debug.Log("Loading Next Level");
                    Invoke("LoadNext", 1.5f);
                }
            }
        }
    }

    void LoadNext()
    {
        SceneManager.LoadScene(nextLevel);
    }

    void BombQuest()
    {
        float minutes = Mathf.Floor(bombTimer / 60);
        float seconds = bombTimer % 60;
        if (txtQuestUpdate != null)
        {
            txtQuestUpdate.text = "Find something to cut the wires before the time runs out. " + minutes.ToString("") + ":" + Mathf.RoundToInt(seconds).ToString("");
        }
       
    }
}