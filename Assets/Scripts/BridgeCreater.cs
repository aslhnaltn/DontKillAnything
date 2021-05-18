using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCreater : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float zOffset = 1f;
    [SerializeField] float xOffset = 1f;
    [SerializeField]
    int winCondition = 26;
    int friendIndex = 1;
    [SerializeField]
    Vector3 target = new Vector3(459f, 3f, -14f);
    [SerializeField] float speed = 10f;
    public bool isWon = false;
    public bool IsWon
    {
        get { return isWon; }
    }
    public bool isPlaced = false;
    public bool IsPlaced
    {
        get { return isPlaced; }
    }
    [SerializeField] float downLength = 5f;

    public void CreateBridge()
    {
        if (GameManager.ObjectToFollow.Count - 1 >= winCondition)
        {
            isWon = true;
            FindObjectOfType<GameManager>().GameWon();
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    if (GameManager.ObjectToFollow.Count - 1 < friendIndex) { return; }
                    GameManager.ObjectToFollow[friendIndex].transform.SetParent(this.transform);
                    GameManager.ObjectToFollow[friendIndex].GetComponent<Rigidbody>().isKinematic = true;
                    GameManager.ObjectToFollow[friendIndex].GetComponent<EnemyAnimatorController>().SetRunningTrue();
                    GameManager.ObjectToFollow[friendIndex].transform.position = this.transform.position + new Vector3((i - 1) * zOffset, 0f, (j - 1) * xOffset);
                    GameManager.ObjectToFollow[friendIndex].transform.eulerAngles = new Vector3(0f, 90f, 0f);
                    friendIndex++;
                }
            }
        }
    }
    private void Update()
    {
        if (isWon && !isPlaced)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
            if (transform.position == target)
            {
                isPlaced = true;
                for (int i = 1; i <= GameManager.ObjectToFollow.Count - 1; i++)
                {
                    GameManager.ObjectToFollow[i].GetComponent<EnemyAnimatorController>().SetRunningFalse();
                }
            }
        }
        if (isPlaced)
        {
            transform.position = Vector3.MoveTowards(transform.position, target - new Vector3(0f, downLength, 0f), speed / 3f);
        }
    }
}
