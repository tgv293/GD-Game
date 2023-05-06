using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene_1 : MonoBehaviour
{
    [SerializeField] private AudioClip playSound;
    [SerializeField] private AudioSource audioSource;
    public void LoadScene()
    {
        audioSource.clip = playSound;
        audioSource.Play();
        StartCoroutine(Load(0.5f));
       
    }

    IEnumerator Load(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 1;
        SceneManager.LoadScene("Choose Map");
    }
}

