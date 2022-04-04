using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] private float thrustForce = 2f;
    [SerializeField] private float rotateSensivity = 0.3f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrusterParticle, rightThrusterParticle, leftThrusterParticle;

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
            StartThrusting();
        }
        else
        {
            audioSource.Stop();
            mainThrusterParticle.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSensivity);
            leftThrusterParticle.Play();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSensivity);
            rightThrusterParticle.Play();
        }

        else
        {
            rightThrusterParticle.Stop();
            leftThrusterParticle.Stop();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustForce);
        mainThrusterParticle.Play();

        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(mainEngine);
    }

    private void ApplyRotation(float rotationPower)
    {
        rb.freezeRotation = true; //We can manually rotate
        transform.Rotate(Vector3.forward * rotationPower);
        rb.freezeRotation = false; //Physic system can take over
    }
}
