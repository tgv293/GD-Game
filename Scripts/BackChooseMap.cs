using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackChooseMap : MonoBehaviour
{
    [SerializeField] private AudioClip playSound;
    [SerializeField] private AudioSource audioSource;
    public void BackChooseMaps()
    {
        audioSource.clip = playSound;
        audioSource.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("Choose Map");
    }
}
