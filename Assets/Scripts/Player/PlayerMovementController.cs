using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    PlayerInputController inputController;
    Rigidbody _rigidbody;
    [SerializeField] float speed = 3f;
    [Space]
    [SerializeField]
    private float angularSpeed = 1f;
    private void Awake()
    {
        inputController = GetComponent<PlayerInputController>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (GameManager.isGameRunning)
        {
            Movement();
        }
    }
    private void Movement()
    {
        //float xVel = inputController.HorizontalInput * transform.forward.x + inputController.VerticalInput *  transform.forward.x;
        //float zVel = inputController.VerticalInput * transform.forward.z + inputController.HorizontalInput *  transform.forward.z;
        //_rigidbody.velocity = new Vector3(xVel, 0f, zVel) * speed;


        _rigidbody.velocity = new Vector3(inputController.HorizontalInput, 0f, inputController.VerticalInput) * speed;
        transform.LookAt(new Vector3(inputController.MousePosition.x, transform.position.y, inputController.MousePosition.z));


        // OLD MOVEMENT SYSTEM
        //_rigidbody.velocity = new Vector3(transform.forward.x*inputController.VerticalInput, 0f, transform.forward.z * inputController.VerticalInput) *speed;
        //_rigidbody.angularVelocity = new Vector3(0f, inputController.HorizontalInput * angularSpeed, 0f);
    }
}
