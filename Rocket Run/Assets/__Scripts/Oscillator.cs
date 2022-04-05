using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    float movementFactor;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float perioid = 2f;

    private void Start()
    {
        startingPos = transform.position;
    }

    private void Update()
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
