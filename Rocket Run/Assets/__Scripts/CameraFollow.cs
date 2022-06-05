using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float minimumX;
    [SerializeField] float maximumX;
    [SerializeField] float offset;

    private void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = (target.position.x - offset);
        position.x = Mathf.Clamp(position.x, minimumX, maximumX);

        transform.position = position;
    }
}
