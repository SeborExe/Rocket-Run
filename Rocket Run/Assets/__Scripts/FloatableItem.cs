using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatableItem : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] float floatingRange = 0.2f;
    [SerializeField] float velocity = 0.0005f;
    private void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        Rotate();
        Move();
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Euler(0, 45 * Time.timeSinceLevelLoad, 45f);
    }

    void Move()
    {
        Vector3 pos = transform.position;
        pos.y += velocity;
        transform.position = Vector3.Lerp(transform.position, pos, 2f);

        if (transform.position.y >= startingPos.y + floatingRange)
            velocity = -velocity;

        if (transform.position.y <= startingPos.y - floatingRange)
            velocity = -velocity;
    }
}
