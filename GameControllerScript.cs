using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    Vector3 startPos;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        startPos = transform.position;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }
    IEnumerator Respawn(float duration)
    {
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        meshRenderer.enabled = true;
    }

}
