using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;

    public Animator spikeTrapAnim; //Animator for the SpikeTrap;

    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        gameObject.GetComponent<BoxCollider>().enabled = true;
        //wait 2 seconds;
        yield return new WaitForSeconds(1.5f);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //wait 2 seconds;
        yield return new WaitForSeconds(1.5f);
        //Do it again;
        StartCoroutine(OpenCloseTrap());

    }
    
}