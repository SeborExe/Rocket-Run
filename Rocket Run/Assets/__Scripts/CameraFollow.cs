using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Following target")]
    [SerializeField] float minimumX;
    [SerializeField] float maximumX;
    [SerializeField] float offset;

    [Header("Start game")]
    [SerializeField] float timeLookingOnLandPad = 2f;
    [SerializeField] Transform Player;
    [SerializeField] Transform LandPad;
    [SerializeField] GameObject MovementButtons;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    private void Start()
    {
        MovementButtons.SetActive(false);
        transform.position = new Vector3(LandPad.transform.position.x, 10, -23);
    }

    private void LateUpdate()
    {
        float time = timeLookingOnLandPad -= Time.deltaTime;
        if (time < 0)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.x, Player.position.x, ref yVelocity, smoothTime);
            newPosition = Mathf.Clamp(newPosition, minimumX, maximumX);
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);

            if (newPosition <= Player.transform.position.x + 0.1f)
            {
                MovementButtons.SetActive(true);
                float pos;
                pos = Player.transform.position.x;
                transform.position = new Vector3(pos, transform.position.y, transform.position.z);
            }
        }
        else
        {
            return;
        }
    }
}
