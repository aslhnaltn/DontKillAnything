using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class FootStep : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    private AudioSource audioSource;
    PlayerInputController inputController;
    bool isPlaying=false;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        inputController = FindObjectOfType<PlayerInputController>();
    }
    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioClips.Length - 1);
        return audioClips[index];
    }
    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && !isPlaying)
        {
            StartCoroutine(StepCoRoutine());
            isPlaying = true;
        }
    }
    IEnumerator StepCoRoutine()
    {
        Step();
        while (Mathf.Abs(inputController.VerticalInput) >= Mathf.Epsilon || Mathf.Abs(inputController.HorizontalInput) >= Mathf.Epsilon)
        {
            yield return new WaitForSeconds(0.3f);
            Step();
        }
        isPlaying = false;
    }
}