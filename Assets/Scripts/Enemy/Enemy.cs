using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyMovementController enemyMovementController;
    [SerializeField] GameObject turnFriendlyVFX;
    public bool IsFoe { get; private set; }
    [SerializeField]
    Material friendlyMaterial;
    [SerializeField]
    Renderer _renderer;

    private void Awake()
    {
        IsFoe = true;
        enemyMovementController = GetComponent<EnemyMovementController>();
        _renderer = GetComponentInChildren<Renderer>();
    }
    public void TurnFriendly()
    {
        _renderer.material = friendlyMaterial;
        Instantiate(turnFriendlyVFX, transform.position, Quaternion.identity);
        IsFoe = false;
        GameManager.ObjectToFollow.Add(gameObject);
        enemyMovementController.FollowIndex = GameManager.ObjectToFollow.Count - 2;
        enemyMovementController.Foe = false;
    }
}
