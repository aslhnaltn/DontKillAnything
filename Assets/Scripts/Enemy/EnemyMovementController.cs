using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    Vector3 targetVector;
    [SerializeField] float fieldOfViewDistance = 30f;
    [SerializeField] float friendlyFollowDistance = 10f;
    Rigidbody _rigidbody;
    [Space] [SerializeField] float speed=5f;
    bool isFollowing = false;
    bool isFoe = true;
    int followIndex = 0;
    float firstFriendlyFollowDistance;
    EnemyAnimatorController enemyAnimator;
    public bool IsDead { get; set; }

    public int FollowIndex
    {
        set { followIndex = value; }
    }
    public bool Foe
    {
        set { isFoe = value;  }
    }

    private void Awake()
    {
        IsDead = false;
        _rigidbody = GetComponent<Rigidbody>();
        firstFriendlyFollowDistance = friendlyFollowDistance * 2f;
        enemyAnimator = GetComponent<EnemyAnimatorController>();
    }

    private void Update()
    {
        if (!GameManager.isGameRunning)
        {
            return;
        }
        Movement();
    }
    private void Movement()
    {
        if (GameManager.ObjectToFollow[followIndex] == null || !GameManager.isGameRunning)
        {
            return;
        }
        if (IsDead) { return; }
        targetVector = GameManager.ObjectToFollow[followIndex].transform.position - transform.position;
        if (isFoe)
        {
            MovementAsFoe();
        }
        else
        {
            if (followIndex == 0) { friendlyFollowDistance = firstFriendlyFollowDistance; }
            MovementAsFriendly();
        }
    }
    private void MovementAsFriendly()
    {
        if (targetVector.magnitude >= friendlyFollowDistance)
        {
            enemyAnimator.SetRunningTrue();
            _rigidbody.velocity = targetVector.normalized * speed;
        }
        else
        {
            enemyAnimator.SetRunningFalse();
        }
        Vector3 lookTarget = new Vector3(GameManager.ObjectToFollow[followIndex].transform.position.x, transform.position.y, GameManager.ObjectToFollow[followIndex].transform.position.z);
        transform.LookAt(lookTarget);
    }
    private void MovementAsFoe()
    {
        if (targetVector.magnitude <= fieldOfViewDistance && !isFollowing)
        {
            isFollowing = true;
        }
        else
        {
            enemyAnimator.SetRunningFalse();
        }
        if (isFollowing)
        {
            enemyAnimator.SetRunningTrue();
            _rigidbody.velocity = targetVector.normalized * speed;
            Vector3 lookTarget = new Vector3(GameManager.ObjectToFollow[followIndex].transform.position.x, transform.position.y, GameManager.ObjectToFollow[followIndex].transform.position.z);
            transform.LookAt(lookTarget);
        }
    }
}
