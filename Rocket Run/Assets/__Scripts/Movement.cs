using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float thrustForce = 2f;
    [SerializeField] private float rotateSensivity = 0.3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustForce);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSensivity);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSensivity);
        }
    }

    private void ApplyRotation(float rotationPower)
    {
        transform.Rotate(Vector3.forward * rotationPower);
    }
}
