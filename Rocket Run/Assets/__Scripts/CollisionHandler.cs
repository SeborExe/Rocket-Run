using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashClip, successClip;
    AudioSource audioSource;

    bool isTransitioning = false;
    bool isCrashed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        var objectCollide = collision.gameObject.tag;

        if (isTransitioning) return;

        switch (objectCollide)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;

            case "Finish":
                StartCoroutine(CheckResult());
                break;

            case "Fuel":
                Debug.Log("Fuel");
                break;

            default:
                isCrashed = true;
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crashClip);
        Invoke("ReloadLevel", 1.5f);
    }

    void StartSuccesSequnce()
    {
        audioSource.PlayOneShot(successClip);
        Invoke("LoadNextLevel", 1f);
    }

    IEnumerator CheckResult()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        for (int i = 3; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(i);
        }

        if (!isCrashed)
            StartSuccesSequnce();
    }

    private void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    private void LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel == SceneManager.sceneCountInBuildSettings)
            nextLevel = 0;

        SceneManager.LoadScene(nextLevel);
    }
}
