using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    GameManager gameManager;
    bool isDead = false;
    BoxCollider _collider;
    Rigidbody rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        _collider = GetComponentInChildren<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isDead)
        {
            MovementAnims();
        }
    }

    private void MovementAnims()
    {
        bool isShooting = anim.GetBool("isShooting");
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("backRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("backRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("rightRun", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("rightRun", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("leftRun", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("leftRun", false);
        }
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("isShooting", true);
            if (isShooting)
            {
                anim.SetBool("refill", true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isShooting", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Traps"))
        {
            rb.isKinematic = true;
            _collider.enabled = false;
            isDead = true;
            anim.SetTrigger("isDieTr");
            gameManager.GameLost();
        }
    }
}
