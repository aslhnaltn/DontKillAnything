using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject water;
    void Start()
    {
        for(int i = 0; i <= 50; i++)
        {
            for (int j = 0; j <= 50; j++)
            {
                Instantiate(water, transform.position + new Vector3(i*10f, 0f, j*10f), Quaternion.identity, this.transform.parent);
            }
        }
    }
}
