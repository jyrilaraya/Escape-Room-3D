using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    public bool isFlashlight;
    public bool isCRKey;
    public bool isScissors;
    public bool isBattery;

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.text = "Press [E] to Pickup";
        }
    }
    private void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (isFlashlight)
                {
                    gameManager.isFlashLightCollected = true;
                    Invoke(" ClearMsg", 1.5f);
                    Destroy(this.gameObject);
                }

                if (isCRKey)
                {
                    gameManager.isCRDoorKeyCollected = true;
                    Invoke(" ClearMsg", 1.5f);
                    Destroy(this.gameObject);
                }

                if (isScissors)
                {
                    gameManager.isScissorsFound = true;
                    Invoke(" ClearMsg", 1.5f);
                    Destroy(this.gameObject);
                }

                if (isBattery)
                {
                    gameManager.isBatteryCollected = true;
                    Invoke("ClearMsg", 1.5f);
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.text = "";
        }   
    }

    void ClearMsg()
    {
        txtInteractMsg.text = "";
    }
}
