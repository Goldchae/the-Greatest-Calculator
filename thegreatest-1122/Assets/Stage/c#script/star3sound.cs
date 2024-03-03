using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star3sound : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("Delay2");
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(1);
        audioSource.Play();
    }
    
}
