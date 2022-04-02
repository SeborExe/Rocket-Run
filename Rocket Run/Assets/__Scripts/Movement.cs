using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] private float thrustForce = 2f;
    [SerializeField] private float rotateSensivity = 0.3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
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
        rb.freezeRotation = true; //We can manually rotate
        transform.Rotate(Vector3.forward * rotationPower);
        rb.freezeRotation = false; //Physic system can take over
    }
}
