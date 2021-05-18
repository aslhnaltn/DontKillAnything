using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaColliderScript : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.Play();
            GameManager.isGameOver = true;
            Debug.Log("Game over");
        }
    }
}
