using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBox2 : MonoBehaviour
{
    private GameObject target; //마우스 클릭 확인용 변수
    
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
        if (Input.GetMouseButtonDown(0)) //피격
        {
            CastRay();

            if (target == this.gameObject)
            {
                GameObject.Find("Tutorial").GetComponent<TutorialScript2>().nextbutton = true;
            }
        }
    }
}