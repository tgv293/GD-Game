using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGame : MonoBehaviour
{
    [SerializeField] private AudioClip playSound;
    [SerializeField] private AudioSource audioSource;

    public GameObject pause;
    
    private void Start()
    {
        pause.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }
    public void GamePause()
    {
        audioSource.clip = playSound;
        audioSource.Play();
        Time.timeScale = 0;
        pause.SetActive(true);

    }
}
