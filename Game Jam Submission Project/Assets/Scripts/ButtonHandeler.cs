﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonHandeler : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int buildNumber)
    {       
        SceneManager.LoadScene(buildNumber);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DisableObject(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
    }

    public void EnableObject(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeTheTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void PlayAudio(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, Vector3.zero);
    }

}
