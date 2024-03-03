using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBarScript : MonoBehaviour
{
    public GameObject punch;

    public GameObject number;
    private GameObject num1; //일의 자리
    private GameObject num2; //십의 자리
    private GameObject num3; //백의 자리
    private GameObject sign;
    private GameObject endnum;

    public int i;
    public int j;
    bool move1; //가운데로 모으기
    bool move2; //왼쪽으로 보내기
    bool move3; //바로!

    float speed = 5f;
    float dis = 0.2f; //숫자 간격

    float x0 = -6f;
    float height = 2.8f;

    Vector2 MousePosition;

    Camera Camera;

    void Start()
    {
        num1 = Instantiate(number, new Vector2(0, 0), transform.rotation);
        num2 = Instantiate(number, new Vector2(0, 0), transform.rotation);
        num3 = Instantiate(number, new Vector2(0, 0), transform.rotation);
        sign = Instantiate(number, new Vector2(0, 0), transform.rotation);
        endnum = Instantiate(number, new Vector2(0, 0), transform.rotation);

        re();

        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void re()
    {
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        sign.SetActive(false);
        endnum.SetActive(false);

        i = 0;
        j = 0;

        move1 = false;
        move2 = false;
        move3 = false;
    }

    void Update()
    {
        if (move1 == true)
            Run1();

        if (move1 == true && endnum.transform.position.x <= x0 + 0.21f)
        {
            Stop1();
        }

        if (move2 == true)
            Run2();

        if (move3 == true)
            Run3();

        if (i == 1)
        {
            if (move3 == true && num1.transform.position.y >= height - 0.1f)
            {
                Stop3();
            }
        }
        if (i == 2)
        {
            if (move3 == true && sign.transform.position.y >= height - 0.1f)
            {
                Stop3();
            }
        }
        if (i == 3)
        {
            if (move3 == true && endnum.transform.position.y >= height - 0.1f)
            {
                move1 = true;
                Stop3();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);
        num3.transform.position = new Vector2(num1.transform.position.x - 4 * dis, num1.transform.position.y);
    }

    public void nummaker()
    {
        Sprite[] spritesN = Resources.LoadAll<Sprite>("number");
        Sprite[] spritesM = Resources.LoadAll<Sprite>("sign");

        if (i != j)
        {
            i = j;
        }

        if (i == 0)
        {
            num1.transform.position = new Vector2(MousePosition.x, MousePosition.y);
            move3 = true;

            num1.SetActive(true);
            SpriteRenderer spriteJ = num1.GetComponent<SpriteRenderer>();
            spriteJ.sprite = spritesN[punch.GetComponent<PunchScript>().attack[0]];

            i++;
            j++;
        }
        else if (i == 1)
        {
            Stop1();
            Stop3();
            sign.transform.position = new Vector2(MousePosition.x, MousePosition.y);
            move2 = true;
            move3 = true;

            sign.SetActive(true);
            SpriteRenderer spriteK = sign.GetComponent<SpriteRenderer>();
            spriteK.sprite = spritesM[punch.GetComponent<PunchScript>().attack[1] - 1];

            i++;
            j++;
        }
        else if (i == 2)
        {
            Stop2();
            Stop3();
            endnum.transform.position = new Vector2(MousePosition.x, MousePosition.y);
            move3 = true;

            endnum.SetActive(true);
            SpriteRenderer spriteL = endnum.GetComponent<SpriteRenderer>();
            spriteL.sprite = spritesN[punch.GetComponent<PunchScript>().attack[2]];

            i++;
            j = 1;
        }
    }

    void Run1Start()
    {
        move1 = true;
    }
    void Run1() //가운데로 모으기
    {
        num1.transform.position = Vector2.MoveTowards(num1.transform.position, new Vector2(x0 - 0.2f, height), Time.deltaTime * speed);
        endnum.transform.position = Vector2.MoveTowards(endnum.transform.position, new Vector2(x0 + 0.2f, height), Time.deltaTime * speed);
    }
    void Stop1() //가운데로 모으기 바로 도착
    {
        endnum.transform.position = new Vector2(x0 + 0.2f, height);

        move1 = false;
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        sign.SetActive(false);
        endnum.SetActive(false);

        Sprite[] spritesN = Resources.LoadAll<Sprite>("number");
        Sprite[] spritesM = Resources.LoadAll<Sprite>("sign");

        int a = punch.GetComponent<PunchScript>().result % 10; //일의 자리
        int b = (punch.GetComponent<PunchScript>().result / 10) % 10; //십의 자리
        int c = punch.GetComponent<PunchScript>().result / 100; //백의 자리

        SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
        spriteA.sprite = spritesN[a];
        SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
        spriteB.sprite = spritesN[b];
        SpriteRenderer spriteC = num3.GetComponent<SpriteRenderer>();
        spriteC.sprite = spritesN[c];

        if (punch.GetComponent<PunchScript>().result > 99 && punch.GetComponent<PunchScript>().result <= 999)
        {
            num1.transform.position = new Vector2(x0 + 2 * dis, height);
            num1.SetActive(true);
            num2.SetActive(true);
            num3.SetActive(true);
        }
        else if (punch.GetComponent<PunchScript>().result > 9 && punch.GetComponent<PunchScript>().result <= 99)
        {
            num1.transform.position = new Vector2(x0 + dis, height);
            num1.SetActive(true);
            num2.SetActive(true);
            num3.SetActive(false);
        }
        else if (punch.GetComponent<PunchScript>().result >= 0 && punch.GetComponent<PunchScript>().result <= 9)
        {
            num1.transform.position = new Vector2(x0, height);
            num1.SetActive(true);
            num2.SetActive(false);
            num3.SetActive(false);
        }
    }

    void Run2() //왼쪽으로 보내기
    {
        num1.transform.position = Vector2.MoveTowards(num1.transform.position, new Vector2(x0 - 1, height), Time.deltaTime * (speed + 3));
    }
    void Stop2() //왼쪽으로 보내기 바로 도착
    {
        num1.transform.position = new Vector2(x0 - 1, height);
        move2 = false;
    }

    void Run3() //날아가게 하기
    {
        if (i == 1)
        {
            num1.transform.position = Vector3.Slerp(num1.transform.position, new Vector3(x0, height), Time.deltaTime * 8);
        }
        else if (i == 2)
        {
            sign.transform.position = Vector3.Slerp(sign.transform.position, new Vector3(x0, height), Time.deltaTime * 8);
        }
        else if (i == 3)
        {
            endnum.transform.position = Vector3.Slerp(endnum.transform.position, new Vector3(x0 + 1, height), Time.deltaTime * 8);
        }
    }
    void Stop3() //날아가게 하기 바로 도착
    {
        if (i == 1)
        {
            num1.transform.position = new Vector2(x0, height);
        }
        else if (i == 2)
        {
            sign.transform.position = new Vector2(x0, height);
        }
        else if (i == 3)
        {
            endnum.transform.position = new Vector2(x0 + 1, height);
            i = 1;
        }
        move3 = false;
    }
}
