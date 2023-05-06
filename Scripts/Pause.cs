using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private AudioClip playSound;
    [SerializeField] private AudioSource audioSource;

    public GameObject pauseMenu;
    public void Pause_Game()
    {
        audioSource.clip = playSound;
        audioSource.Play();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
}
