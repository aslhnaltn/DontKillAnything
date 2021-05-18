using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    void Start()
    {
        rb.velocity = transform.parent.forward * speed;
        Destroy(gameObject, 20f);
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        var healt = hitInfo.GetComponentInParent<EnemyHealth>();
        if (healt != null)
        {
            healt.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
