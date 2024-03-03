using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    public GameObject num1;
    public GameObject num2;

    public int number;
    public int result;

    public bool tremble;
    bool move;
    float speed1 = 4f;
    float x0;
    float x1;

    bool movey;
    float speed2 = 0.08f;
    public float y0;
    public float y1;

    void Start()
    {
        movey = true;
    }

    void FixedUpdate()
    {
        if (movey == false)
            num1.transform.position = num1.transform.position + transform.up * speed2 * Time.deltaTime;
        else if (movey == true)
            num1.transform.position = num1.transform.position - transform.up * speed2 * Time.deltaTime;

        if (tremble == true)
        {
            if (move == false) //仆之仆之
            {
                num1.transform.position = new Vector2(num1.transform.position.x - speed1 * Time.deltaTime, num1.transform.position.y);
            }
            else if (move == true) //仆之仆之
            {
                num1.transform.position = new Vector2(num1.transform.position.x + speed1 * Time.deltaTime, num1.transform.position.y);
            }
        }
        num2.transform.position = new Vector2(num1.transform.position.x - 0.5f, num1.transform.position.y);
    }

    void Update()
    {
        if (num1.transform.position.y <= y1)
            movey = false;
        else if (num1.transform.position.y >= y0)
            movey = true;

        if (tremble == true)
        {
            if (num1.transform.position.x >= x1)
                move = false;
            else if (num1.transform.position.x <= x0)
                move = true;
        }
    }

    public void nummaker()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number3");
        int b = result / 10;
        int a = result % 10;
        SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
        spriteA.sprite = sprites[a];
        SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
        spriteB.sprite = sprites[b];
    }

    public void Tremble() //測測 л熱
    {
        CancelInvoke("Stop");
        move = true;
        x0 = num1.transform.position.x;
        x1 = x0 + 0.05f;
        tremble = true;

        Invoke("Stop", 0.3f);
    }
    void Stop()
    {
        num1.transform.position = new Vector2(x0, num1.transform.position.y);
        move = false;
        tremble = false;
    }
}