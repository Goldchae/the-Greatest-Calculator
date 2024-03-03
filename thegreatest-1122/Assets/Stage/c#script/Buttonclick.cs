using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonclick : MonoBehaviour
{
    public GameObject punch;
    public GameObject numberbar;

    public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14; //버튼

    //숫자
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;
    public GameObject num7;
    public GameObject num8;
    public GameObject num9;
    //연산기호
    public GameObject sign1;
    public GameObject sign2;
    public GameObject sign3;
    public GameObject sign4;
    //초기화
    public GameObject re;

    public bool pausemode;

    void Start() //클릭하면
    {
        btn1.onClick.AddListener(() => btnprint(num1));
        btn2.onClick.AddListener(() => btnprint(num2));
        btn3.onClick.AddListener(() => btnprint(num3));
        btn4.onClick.AddListener(() => btnprint(num4));
        btn5.onClick.AddListener(() => btnprint(num5));
        btn6.onClick.AddListener(() => btnprint(num6));
        btn7.onClick.AddListener(() => btnprint(num7));
        btn8.onClick.AddListener(() => btnprint(num8));
        btn9.onClick.AddListener(() => btnprint(num9));
        btn10.onClick.AddListener(() => btnprint(sign1));
        btn11.onClick.AddListener(() => btnprint(sign2));
        btn12.onClick.AddListener(() => btnprint(sign3));
        btn13.onClick.AddListener(() => btnprint(sign4));
        btn14.onClick.AddListener(() => btnprint(re));

        pausemode = false;
    }
    
    void btnprint(GameObject Num)
    {
        if (pausemode == false && GameObject.Find("ending").GetComponent<endingscene>().ending == false)
        {
            if (Num == num1)
            {
                punch.GetComponent<PunchScript>().num = 1;
            }
            else if (Num == num2)
            {
                punch.GetComponent<PunchScript>().num = 2;
            }
            else if (Num == num3)
            {
                punch.GetComponent<PunchScript>().num = 3;
            }
            else if (Num == num4)
            {
                punch.GetComponent<PunchScript>().num = 4;
            }
            else if (Num == num5)
            {
                punch.GetComponent<PunchScript>().num = 5;
            }
            else if (Num == num6)
            {
                punch.GetComponent<PunchScript>().num = 6;
            }
            else if (Num == num7)
            {
                punch.GetComponent<PunchScript>().num = 7;
            }
            else if (Num == num8)
            {
                punch.GetComponent<PunchScript>().num = 8;
            }
            else if (Num == num9)
            {
                punch.GetComponent<PunchScript>().num = 9;
            }
            else if (Num == sign1)
            {
                punch.GetComponent<PunchScript>().sign = 1;
            }
            else if (Num == sign2)
            {
                punch.GetComponent<PunchScript>().sign = 2;
            }
            else if (Num == sign3)
            {
                punch.GetComponent<PunchScript>().sign = 3;
            }
            else if (Num == sign4)
            {
                punch.GetComponent<PunchScript>().sign = 4;
            }

            if (Num == re)
            {
                punch.GetComponent<PunchScript>().re();
                punch.GetComponent<PunchScript>().ScrollChange2();
            }
            else
            {
                punch.GetComponent<PunchScript>().calculator(); //버튼 클릭할 때마다 펀치 스크립트에서 계산 함수 실행
            }
        }
    }
}
