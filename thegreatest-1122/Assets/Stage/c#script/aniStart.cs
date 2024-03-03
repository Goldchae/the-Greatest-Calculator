using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniStart : MonoBehaviour
{
    public GameObject paper;
    public Animator animator; 
    public GameObject donepaper;

    void Start()
    {
        animator = paper.GetComponent<Animator>(); 
        animator.SetTrigger("start"); 
        donepaper.SetActive(false);
    }
}
