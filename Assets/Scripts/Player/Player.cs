using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private void Start()
    {
        GameManager.ObjectToFollow.Add(gameObject);
    }
}
