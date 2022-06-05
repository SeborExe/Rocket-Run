using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatableItem : MonoBehaviour
{
    Vector3 startingPos;
    float movementFactor;
    [SerializeField] Vector3 movementVector = new Vector3(0, 0.2f, 0);
    [SerializeField] float perioid = 3f;
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
        if (perioid <= Mathf.Epsilon) return;

        float cycles = Time.time / perioid; // continually growing over time
        const float tau = Mathf.PI * 2; // constant value of 6.28

        float rawSinWave = Mathf.Sin(cycles * tau); // goind from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; //recalculation to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
