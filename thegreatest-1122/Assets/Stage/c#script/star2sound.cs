using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star2sound : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource.Play();
    }
}
