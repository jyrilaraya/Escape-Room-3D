using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerScript : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter(Collider other)
    {
        print("Next Level");

        if (other.tag == "Player")
        {
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}


