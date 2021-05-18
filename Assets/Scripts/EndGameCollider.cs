using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.isGameRunning = false;
            FindObjectOfType<BridgeCreater>().CreateBridge();
        }
    }
}
