using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesBehaviour : MonoBehaviour
{
    Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation, Space.World);
    }
}
