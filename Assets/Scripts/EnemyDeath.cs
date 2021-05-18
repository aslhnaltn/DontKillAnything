using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Enemy enemy;
    EnemyAnimatorController animatorController;
    bool isAnimationPlaying = false;
    float timer = 0f;
    bool isDead = false;
    float localScale = 1f;
    [SerializeField]
    bool isDieable = true;
    EnemyMovementController movementController;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<Enemy>();
        movementController = GetComponent<EnemyMovementController>();
    }

    private void Update()
    {
        if (isDead)
        {
            timer += Time.deltaTime;
            localScale = 5f - (timer*3f);
            gameObject.transform.localScale = new Vector3(localScale,localScale,localScale);
            transform.position = new Vector3(transform.position.x, transform.position.y + timer * 3f, transform.position.z);
            if (gameObject.transform.localScale.x <= 0.01f) { Destroy(gameObject); }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && enemy.IsFoe)
        {
            if (isDieable)
            {
                if (!isDead) { GameManager.deathCount++; movementController.IsDead = true; rb.useGravity = false; }
                isDead = true;
            }
        }
    }
}
