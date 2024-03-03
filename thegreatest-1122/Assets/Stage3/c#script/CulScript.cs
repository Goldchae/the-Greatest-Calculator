using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CulScript : MonoBehaviour
{
    AudioSource audioSource;/////////////소리
    public AudioClip culcome;
    public AudioClip SwordR;
    public AudioClip cal1appear;
    public AudioClip culgoaway;

    void PlaySound(string action){
        switch (action){
            case "culcome":
                audioSource.clip = culcome;
                break;
            case "SwordR":
                audioSource.clip = SwordR;
                break;
            case "cal1appear":
                audioSource.clip = cal1appear;
                break;
            case "culgoaway":
                audioSource.clip = culgoaway;
                break;
        }
        audioSource.Play();
    }

    public Animator animator;

    public GameObject AttackBar;
    public GameObject KalAttackBar;
    public GameObject stage;
    public GameObject story;
    public GameObject punch;

    private GameObject target; //마우스 클릭 확인용 변수

    public int heart; //큘 체력

    //큘 이동 관련
    public int move; //큘 이동 변수
    bool stop;
    float xb = 7f;
    float yb = -0.6f;
    float speed = 3f;

    //큘 ㅂㄷㅂㄷ, 둥둥 관련
    public int movey; //좌우상하
    private bool tremble; //큘 ㅂㄷㅂㄷ 변수
    float x0;
    float x1;
    float speed1 = 3f;
    float y0; //큘 둥둥 변수
    float y1;
    float speed2 = 0.4f;

    //난수 표시 관련
    int random;
    public GameObject number;
    private GameObject num1; //일의 자리
    private GameObject num2; //십의 자리
    float dis = 0.25f;
    float dis1 = 2.5f; //숫자 머리 위 간격

    //칼 날라가기~
    public GameObject AttackBar1;
    public GameObject flynum;
    private GameObject fnum1; //일의 자리
    private GameObject fnum2; //십의 자리
    GameObject fly;
    float xk = 6.5f;
    float yk = 2.8f;
    int anum;
    float xn = 6f;
    float yn = 2.8f;
    public float xf;
    public float yf;
    float speed3 = 7.5f;
    bool flymode;
    int numnum;
    bool timer;
    float time;

    public GameObject KerWongi;
    float xP = 20;
    float yP = 1;
    float speed4 = 2f;
    int movek;

    void Start() //게임 시작 초기화
    {
        audioSource = GetComponent<AudioSource>();/////////////소리
        animator = GetComponent<Animator>();

        heart = 100;

        transform.position = new Vector2(xb + 7, transform.position.y);
        move = 0;
        stop = false;

        tremble = false;

        movey = 3;
        y0 = transform.position.y;
        y1 = y0 + 0.2f;

        AttackBar.SetActive(false);

        num1 = Instantiate(number, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        num2 = Instantiate(number, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        num1.SetActive(false);
        num2.SetActive(false);

        fly = Instantiate(AttackBar1, new Vector2(xk, yk), transform.rotation);
        fly.SetActive(false);
        flymode = false;
        fnum1 = Instantiate(flynum, new Vector2(xn, yn), transform.rotation);
        fnum2 = Instantiate(flynum, new Vector2(xn - 0.4f, yn), transform.rotation);
        fnum1.SetActive(false);
        fnum2.SetActive(false);

        timer = false;

        KerWongi.transform.position = new Vector2(xP, yP);
        movek = 0;
    }

    void FixedUpdate()
    {
        if (random > 9 && random <= 99) //십의 자리일 때
        {
            num1.transform.position = new Vector2(transform.position.x + dis, transform.position.y + dis1);
        }
        else if (random > 0 && random <= 9) //일의 자리일 때
        {
            num1.transform.position = new Vector2(transform.position.x, transform.position.y + dis1);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);

        if (move == 1)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xb, transform.position.y), Time.deltaTime * (speed + 2));

        if (move == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xb + 7, transform.position.y), Time.deltaTime * (speed + 2));
        }

        if (movey == 1) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x - speed1 * Time.deltaTime, transform.position.y);
        else if (movey == 2) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x + speed1 * Time.deltaTime, transform.position.y);

        if (movey == 3) //둥둥
            transform.position = transform.position - transform.up * speed2 * Time.deltaTime;
        else if (movey == 4)
            transform.position = transform.position + transform.up * speed2 * Time.deltaTime;

        if (flymode == true)
        {
            fly.transform.position = Vector2.Lerp(fly.transform.position, new Vector2(xf, yf), Time.deltaTime * speed3);
        }
        if (fly.transform.position.x <= xf + 1.5f && flymode == true)
        {
            Flyoff();
        }

        if (movek == 1)
        {
            KerWongi.transform.position = Vector3.Lerp(KerWongi.transform.position, new Vector2(transform.position.x - 3f, KerWongi.transform.position.y), Time.deltaTime * speed4); ;
        }

        if (movek == 2)
        {
            KerWongi.transform.position = new Vector2(transform.position.x - 3f, KerWongi.transform.position.y);
        }
    }

    void Update()
    {
        if (tremble == true)
        {
            if (transform.position.x >= x1)
                movey = 1;
            else if (transform.position.x <= x0)
                movey = 2;
        }

        if (transform.position.y >= y1 && stop == false)
            movey = 3;
        else if (transform.position.y <= y0 && stop == false)
            movey = 4;

        if (timer == true)
        {
            time -= Time.deltaTime;
        }
        
        if(time <= 0)
        {
            if (GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().going == 1)
            {
                Timer();
                CulPlus();
            }
            else
            {
                timer = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.D)) //임의 피격
        {
            CulPlus();
        }

        if (GameObject.Find("ending").GetComponent<endingscene>().ending == true)
        {
            AllStop();
        }
    }

    void setting() //난수 설정
    {
        random = Random.Range(30, 40);
        nummaker();
    }

    void nummaker() //플레이어 머리 위 난수 생성 함수
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        if (random > 9 && random <= 99) //난수가 십의 자리일 때
        {
            int b = random / 10;
            int a = random % 10;
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[a];
            SpriteRenderer spriteB = num2.GetComponent<SpriteRenderer>();
            spriteB.sprite = sprites[b];

            num1.SetActive(true);
            num2.SetActive(true);
        }
        else if (random > 0 && random <= 9) //난수가 일의 자리일 때
        {
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[random];

            num1.SetActive(true);
            num2.SetActive(false);
        }
    }

    public void Timer()
    {
        time = Random.Range(6, 8);
        timer = true;
    }

    public void CulPlus()
    {
        numnum = Random.Range(1, 6);
        if (numnum == 1)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum1;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x1;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y1;
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().who1 = 2;
        }
        else if (numnum == 2)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum2;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x2;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y2;
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().who2 = 2;
        }
        else if (numnum == 3)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum3;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x3;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y3;
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().who3 = 2;
        }
        else if (numnum == 4)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum4;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x4;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y4;
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().who4 = 2;
        }
        else if (numnum == 5)
        {
            anum = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().anum5;
            xf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().x5;
            yf = GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().y5;
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().who5 = 2;
        }
        flynummaker();
        Invoke("Fly", 1f);
    }

    void flynummaker() //플레이어 머리 위 난수 생성 함수
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        int b = anum / 10;
        int a = anum % 10;
        SpriteRenderer spriteC = fnum1.GetComponent<SpriteRenderer>();
        spriteC.sprite = sprites[a];
        SpriteRenderer spriteD = fnum2.GetComponent<SpriteRenderer>();
        spriteD.sprite = sprites[b];

        fnum1.SetActive(true);
        fnum2.SetActive(true);
    }

    public void Fly()
    {
        animator.SetTrigger("attack");
        PlaySound("SwordR");
        fly.SetActive(true);
        fnum1.SetActive(false);
        fnum2.SetActive(false);
        flymode = true;

        float r1 = Mathf.Atan2(yf - yk, xf - xk) * Mathf.Rad2Deg + 180;
        fly.transform.rotation = Quaternion.Euler(0, 0, r1);
    }
    public void Flyoff()
    {
        if (numnum == 1)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num1setting();
        }
        else if (numnum == 2)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num2setting();
        }
        else if (numnum == 3)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num3setting();
        }
        else if (numnum == 4)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num4setting();
        }
        else if (numnum == 5)
        {
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num5setting();
        }

        fly.transform.position = new Vector2(xk, yk);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode = false;
    }
    public void realFlyoff()
    {
        fnum1.SetActive(false);
        fnum2.SetActive(false);
        fly.SetActive(false);
        flymode = false;
    }

    public void KerWongiOn()
    {
        KerWongi.transform.position = new Vector2(0, yP);
        PlaySound("cal1appear");
        Invoke("Surprise", 0.5f);
        Invoke("Story3", 3f);
    }
    void Surprise()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("surprise");
    }

    public void AttackBarOn()
    {
        Invoke("AttackBarOn_", 0.5f);
    }
    public void AttackBarOn_()
    {
        AttackBar.SetActive(true);
        KalAttackBar.SetActive(true);
    }
    public void AttackBarOff()
    {
        AttackBar.SetActive(false);
        KalAttackBar.SetActive(false);
    }

    public void move1()
    {
        transform.position = new Vector2(xb + 7, transform.position.y);
        transform.localScale = new Vector3(1, 1, 1);
        move = 1;
    }
    public void move2()
    {
        Invoke("move2_", 1.5f);
    }
    void move2_()
    {
        move = 2;
        PlaySound("culgoaway");
        transform.localScale = new Vector3(-1, 1, 1);
    }

    void Story3()
    {
        GameObject.Find("Story").GetComponent<Story3Script>().Story3On();
        KerWongi.GetComponent<KerWongiScript>().twingkle();
        Invoke("Story3_1", 2f);
    }
    void Story3_1()
    {
        GameObject.Find("Story").GetComponent<Story3Script>().Story3_1On();
        Invoke("Story3_15", 1f);
    }
    void Story3_15()
    {
        GameObject.Find("Story").GetComponent<Story3Script>().Story3_15On();
        animator.SetTrigger("attack");
        Invoke("Story3_2", 0.5f);
    }
    void Story3_2()
    {
        GameObject.Find("Story").GetComponent<Story3Script>().Story3_2On();
        KerWongi.GetComponent<KerWongiScript>().Boom();
        transform.position = new Vector2(transform.position.x, yb);
        stop = true;
        movey = 0;
        Invoke("OuchAni", 0.2f);
        Invoke("Story4", 4f);
    }
    void OuchAni()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetBool("ouch", true);
        animator.SetBool("ouch", true);
    }
    void Story4()
    {
        GameObject.Find("Story").GetComponent<Story3Script>().Story4On();
        Invoke("StandingAni", 2f);
        Invoke("Story4_2", 6f);
    }
    void StandingAni()
    {
        animator.SetTrigger("standing");
        Invoke("DungDung", 1.5f);
        Invoke("movek_", 2f);
    }
    void DungDung()
    {
        stop = false;
    }
    void movek_()
    {
        movek = 1;
    }
    void Story4_2()
    {
        GameObject.Find("Story").GetComponent<Story3Script>().Story4_2On();
        Invoke("Story5", 5f);
        xb += 10;
        speed = 2;
        movek = 2;
        Invoke("move2_", 0.5f);
    }
    void Story5()
    {
        GameObject.Find("Story").GetComponent<Story3Script>().Story5On();
        Invoke("Ending", 2f);
    }
    void Ending()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().StageEnding();
    }

    void AllStop()
    {
        move2();
    }
}