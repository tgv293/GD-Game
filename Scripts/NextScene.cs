using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NextScene : MonoBehaviour
{
    [SerializeField] private AudioClip playSound;
    [SerializeField] private AudioSource audioSource;
    public void Next()
    {
        audioSource.clip = playSound;
        audioSource.Play();
        SceneManager.LoadScene("GamePlay_1");
    }
}
