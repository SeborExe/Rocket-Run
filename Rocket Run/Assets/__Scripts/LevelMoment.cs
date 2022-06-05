using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMoment : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] GameObject leftBtn, rightBtn;
    private void Start()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;

        if (scene == 0)
        {
            //playerMovement.thrustForcePower *= 5;
            //leftBtn.SetActive(false);
        }
    }
}
