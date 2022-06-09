using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRocket : MonoBehaviour
{
    [Header("Menu Rocket")]
    [SerializeField] GameObject rocket;
    Rigidbody rb;
    Camera mainCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        CameraFollow();
        StartThrusting();
    }

    void StartThrusting()
    {
        rocket.transform.rotation = Quaternion.Euler(0, Time.timeSinceLevelLoad * 2f, 0);
    }

    void CameraFollow()
    {
        mainCamera.transform.LookAt(rb.transform.position);

        float pos = rb.transform.position.y;
        mainCamera.transform.position = new Vector3(0, pos, -3);
    }
}
