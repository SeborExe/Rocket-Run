using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRocket : MonoBehaviour
{
    [Header("Menu Rocket")]
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
        //StartThrusting();
    }

    void StartThrusting()
    {
        //rb.AddRelativeForce(Vector3.up);
    }

    void CameraFollow()
    {
        mainCamera.transform.LookAt(rb.transform.position);

        float pos = rb.transform.position.y;
        mainCamera.transform.position = new Vector3(0, pos, -3);
    }
}
