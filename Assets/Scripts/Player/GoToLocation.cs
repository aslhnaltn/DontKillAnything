using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GoToLocation : MonoBehaviour
{
    [Header("Player")]
    public GameObject targetLocation;
    public Vector3 target;
    private Vector3 lostTarget;
    Rigidbody rb;
    AnimationController animationController;
    float moveSpeed = 0.4f;
    public BoxCollider bodyCollider;

    [Header("Camera")]
    public GameObject cam;
    public Transform cameraTarget;
    public Vector3 offset;
    public float speed = 0.125f;
    Vector3 lerpLook = new Vector3();
    private bool isColliderOff = false;
    bool isFinished = false;
    CameraFollow cameraFollow;
    GameManager gameManager;
    BridgeCreater bridgeCreater;
    bool isDrowning = false;

    void Awake()
    {
        animationController = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody>();
        target = targetLocation.transform.position;
        lostTarget = target + new Vector3(-60f, 0, 0);
        cameraFollow = FindObjectOfType<CameraFollow>();
        gameManager = FindObjectOfType<GameManager>();
        bridgeCreater = FindObjectOfType<BridgeCreater>();
    }

    private void Update()
    {
        if (isFinished)
        {
            if (!isColliderOff)
            {
                rb.isKinematic = true;
                isColliderOff = true;
                bodyCollider.enabled = false;
            }
            if (bridgeCreater.isPlaced)
            {
                Walk(target);
            }
            else if (!bridgeCreater.isWon)
            {
                DeepToWater();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            isFinished = true;
        }
    }

    private void FixedUpdate()
    {
        if (this.transform.position == targetLocation.transform.position)
        {
            animationController.anim.SetBool("isRunning", false);
            CameraLook();
        }
    }

    public void Walk(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, moveSpeed);
        animationController.anim.SetBool("isRunning", true);
    }

    void DeepToWater()
    {
        gameManager.IsGameLost = true;
        rb.isKinematic = true;
        if (!isDrowning)
        {
            Walk(lostTarget);
        }
        if (transform.position == lostTarget)
        {
            isDrowning = true;
            moveSpeed = 0f;
            transform.position= Vector3.MoveTowards(transform.position, lostTarget - Vector3.down * 20f, moveSpeed);
        }
    }

    void CameraLook()
    {
        cameraFollow.IsGameEnd = true;
        Vector3 position = cameraTarget.position + offset;
        Vector3 lerpPosition = Vector3.Lerp(cam.transform.position, position, speed * 7f * Time.deltaTime);
        cam.transform.position = lerpPosition;
        lerpLook = Vector3.Lerp(cameraTarget.position, lerpPosition, speed * 7f * Time.deltaTime);
        cam.transform.LookAt(lerpLook);
    }


}
