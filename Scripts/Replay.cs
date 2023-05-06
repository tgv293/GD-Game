using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    [SerializeField] private AudioClip playSound;
    [SerializeField] private AudioSource audioSource;
    public void ReplayGame()
    {
        audioSource.clip = playSound;
        audioSource.Play();
        SceneManager.LoadScene("Choose Map");
    }
}
