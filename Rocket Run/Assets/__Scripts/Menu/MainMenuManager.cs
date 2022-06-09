using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        int highestLevel = LevelStats.GetHighestLevel();

        if (highestLevel == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + highestLevel);
    }
}
