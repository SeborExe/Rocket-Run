using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMoment : MonoBehaviour
{
    Movement playerMovement;
    [SerializeField] GameObject leftBtn, rightBtn;
    private void Start()
    {
        playerMovement = FindObjectOfType<Movement>().GetComponent<Movement>();
        int scene = SceneManager.GetActiveScene().buildIndex;

        if (scene == 0)
        {
            //playerMovement.thrustForcePower *= 5;
            //leftBtn.SetActive(false);
        }
    }
}
