using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KerWongiScript : MonoBehaviour
{
    AudioSource audioSource;/////////////소리
    public AudioClip calBomb;
    public AudioClip caltwingle;
    void PlaySound(string action){
        switch (action){
            case "calBomb":
                audioSource.clip = calBomb;
                break;
            case "caltwingle":
                audioSource.clip = caltwingle;
                break;
        }
        audioSource.Play();
    }

    bool move;
    float speed1 = 0.2f;
    float y0;
    float y1;

    public float myTimeScale = 1f;
    float myDeltaTime;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();/////////////소리
        move = false;
        y0 = transform.position.y;
        y1 = y0 - 0.1f;
    }

    void Update()
    {
        myDeltaTime = Time.unscaledDeltaTime * myTimeScale;

        if (transform.position.y <= y1)
            move = false;
        else if (transform.position.y >= y0)
            move = true;

        if (move == false)
            transform.position = transform.position + transform.up * speed1 * myDeltaTime;
        else if (move == true)
            transform.position = transform.position - transform.up * speed1 * myDeltaTime;
    }

    public void twingkle()
    {
        animator.SetBool("effect1", true);
    }
    public void twingklesound()
    {
        PlaySound("caltwingle");
    }

    public void Boom()
    {
        animator.SetTrigger("effect2");
        animator.SetBool("effect1", false);
    }
    public void BoomSound()
    {
        PlaySound("calBomb");
    }
}
