using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningCircle : MonoBehaviour
{
    public float _velocity;
    void Update()
    {
        transform.Rotate(0, 0, _velocity * Time.deltaTime);
    }
}
