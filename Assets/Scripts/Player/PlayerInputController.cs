using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    Plane plane;
    public Vector3 worldPosition;
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public Vector3 MousePosition { get; private set; }

    private void Start()
    {
        plane = new Plane(Vector3.up, 0);
    }

    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
        MousePosition = worldPosition;
    }
}
