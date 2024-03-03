using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxScript3 : MonoBehaviour
{
    private GameObject target; //마우스 클릭 확인용 변수

    AudioSource audioSource; /////////////소리
    public AudioClip click;
    void Start(){
        audioSource = GetComponent<AudioSource>();/////////////소리
    }
    void CastRay() //마우스 클릭 확인용 함수
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
            audioSource.Play();

            if (target == this.gameObject)
            {
                GameObject.Find("Story").GetComponent<Story3Script>().clickNextButton = true;
                audioSource.clip = click;/////////소리
                audioSource.Play(); /////////소리
            }
        }
    }
}