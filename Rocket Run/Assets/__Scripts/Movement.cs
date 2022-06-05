using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    CollisionHandler collisionHandler;

    [SerializeField] private float thrustForce = 2f;
    [SerializeField] private float rotateSensivity = 0.3f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrusterParticle, rightThrusterParticle, leftThrusterParticle;

    public bool thrust { get; set; }
    public bool leftRot { get; set; }
    public bool rightRot { get; set; }

    public float thrustForcePower { get => thrustForce; set => thrustForce = value; }
    public float rotateSensivityValue { get => rotateSensivity; set => rotateSensivity = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collisionHandler = GetComponent<CollisionHandler>();

        thrust = false;
        leftRot = false;
        rightRot = false;
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();

        if (transform.position.y >= collisionHandler.maxHeight)
        {
            collisionHandler.isCrashed = true;
            collisionHandler.StartCrashSequence();
        }
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || thrust)
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
        if (Input.GetKey(KeyCode.A) || leftRot)
        {
            ApplyRotation(rotateSensivity);
            leftThrusterParticle.Play();
        }

        else if (Input.GetKey(KeyCode.D) || rightRot)
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
