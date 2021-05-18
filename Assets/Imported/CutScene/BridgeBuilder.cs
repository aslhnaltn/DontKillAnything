using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BridgeBuilder : MonoBehaviour
{
    [Header("For Veriables")]
    //public Animation animation;
    //public AnimationClip walk;
    //public AnimationClip deep;
    [SerializeField] int enemyCountX = 5;
    [SerializeField] int enemyCountY = 6;
    Vector3 offset;

    [Space]
    [Header("Enemy")]
    [SerializeField] GameObject friendlyEnemy;
    List<GameObject> enemies = new List<GameObject>();
    
    void Start()
    {
        //animation = GetComponent<Animation>();
        offset = new Vector3(0f, 0f, 0f);
        int count = GameManager.ObjectToFollow.Count;
        Debug.Log("Enemy count :" + count);
        SpawnEnemy();
    } 

    void SpawnEnemy()
    {
        for (int i = 0; i < enemyCountY; i++)
        {
            for (int j = 0; j < enemyCountX; j++)
            {
                GameObject enemy = Instantiate(friendlyEnemy, transform);
                enemy.transform.position = this.transform.position + offset;
                enemies.Add(enemy);
                //WalkAnimation();
                //DeepAnimation();

                if (enemies.Count<GameManager.ObjectToFollow.Count)
                {
                    return;
                }
            }

            offset = offset + new Vector3(0, 0, 10);
        }
    }

    //void WalkAnimation()
    //{
    //    animation.Play();
    //}
    //void DeepAnimation()
    //{
    //    animation.Play();
    //}



}
