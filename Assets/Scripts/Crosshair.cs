using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Vector3 correctionVector = new Vector3();
    void Update()
    {
        transform.position = Input.mousePosition + correctionVector;
    }
}
