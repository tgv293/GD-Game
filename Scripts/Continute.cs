using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continute : MonoBehaviour
{
    [SerializeField] private AudioClip playSound;
    [SerializeField] private AudioSource audioSource;

    public GameObject continute;
    public void Continutes()
    {
        audioSource.clip = playSound;
        audioSource.Play();
        Time.timeScale = 1;
        continute.SetActive(false);
    }
}
