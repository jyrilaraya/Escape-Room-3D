using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractWithFurnitures : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    [Header("Interactive furnitures")]
    public bool isCRDoor;
    public bool isNightStand;
    public bool isBed;
    public bool isDresser;
    public bool isTrash;
    public bool isToilet;

    [Header("Collectible Items")]
    public GameObject flashlight;
    public GameObject crKey;
    public GameObject bombObject;
    public GameObject Battery;

    void OnTriggerEnter(Collider actor)
    {
       if (actor.CompareTag("Player"))
        {
            if (isBed)
            {
                if (gameManager.isFlashLightCollected)
                {
                    txtInteractMsg.text = "Press [E] to Interact";
                }
                else
                {
                    txtInteractMsg.text = "";
                }
                
            }

            if (isToilet)
            {
                if (!gameManager.isBombFound)
                {
                    txtInteractMsg.text = "Press [E] to Interact";
                }
                else
                {
                    txtInteractMsg.text = "";
                }
            }
        }
    }

    private void OnTriggerStay(Collider actor)
    {
       if (actor.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (isCRDoor)
                {
                    if (gameManager.isCRDoorKeyCollected)
                    {
                        txtInteractMsg.text = "";
                        Destroy(GameObject.Find("CRDoor"));
                    }
                    else
                    {
                        txtInteractMsg.text = "It's locked, I need to find something to open it...";
                    }
                }
                
                else if (isNightStand)
                {
                    if (flashlight.gameObject != null)
                    {
                        flashlight.gameObject.SetActive(true);
                    }
                    txtInteractMsg.text = "A flashlight.. I might need this later.";
                    if (gameManager.isFlashLightCollected || flashlight.gameObject == null)
                    {
                        txtInteractMsg.text = "There's nothing here to collect..";
                    }
                }

                else if (isBed)
                {
                    if (gameManager.isFlashLightCollected)
                    {
                        crKey.gameObject.SetActive(true);
                        txtInteractMsg.text = "A Key, I'll try this on the CR Door";
                    }
                    if (gameManager.isCRDoorKeyCollected || crKey.gameObject == null)
                    {
                        txtInteractMsg.text = "There's nothing here to collect..";
                    }
                }

                else if (isTrash)
                {
                    gameObject.SetActive(true);
                    txtInteractMsg.text = "";
                }

                else if (isToilet)
                {
                    if (!gameManager.isBombDisarmed)
                    {
                        bombObject.gameObject.SetActive(true);
                    }
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

        else if (isTrash)
        {
            gameObject.SetActive(true);
            txtInteractMsg.text = "";
        }
        
        else if (isToilet)
        {
            if (!gameManager.isBombDisarmed)
            {
                bombObject.gameObject.SetActive(true);
            }
        }

        else
        {
            txtInteractMsg.text = "There's nothing here...";
        }
    }
}
