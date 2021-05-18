using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void GameOver()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
        animator.SetBool("GameOver", true);
    }

    public void SetRunningTrue()
    {
        animator.SetBool("Run", true);
    }

    public void SetRunningFalse()
    {
        animator.SetBool("Run", false);
    }

    public void SetAttackTrue()
    {
        animator.SetBool("Attack", true);
    }

    public void SetAttackFalse()
    {
        animator.SetBool("Attack", false);
    }

    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }

    public void TriggerTakeDamage()
    {
        animator.SetTrigger("TakeDamage");
    }

}
