using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Transform _createFloorPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateFloor();
    }

    void CreateFloor()
    {
        if (transform.position.x < -_createFloorPoint.position.x)
        {
            transform.position = _createFloorPoint.position;
        }
    }
}
