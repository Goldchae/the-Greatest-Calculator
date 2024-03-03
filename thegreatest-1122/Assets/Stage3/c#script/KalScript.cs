using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalScript : MonoBehaviour
{
    AudioSource audioSource;/////////////소리
    public AudioClip healsuccess;
    public AudioClip error;
    public AudioClip opps;
    public AudioClip moncome;
    void PlaySound(string action){
        switch (action){
            case "healsuccess":
                audioSource.clip = healsuccess;
                break;
            case "error":
                audioSource.clip = error;
                break;
            case "opps":
                audioSource.clip = opps;
                break;
            case "moncome":
                audioSource.clip = moncome;
                break;
        }
        audioSource.Play();
    }
    public Animator animator;

    public GameObject Cul;
    public GameObject stage;
    public GameObject story;
    public GameObject punch;

    public int heart; //플레이어 체력

    //플레이어 이동 관련
    public int move; //플레이어 이동 변수
    float speed = 3f;

    //플레이어 ㅂㄷㅂㄷ 관련
    private bool tremble; //플레이어 ㅂㄷㅂㄷ 변수
    private int movey; //좌우
    float x0;
    float x1;
    float speed1 = 3f;

    bool healmode; //힐모드 제어용 변수
    int random; //힐모드 난수
    //난수 표시 관련
    public GameObject number;
    private GameObject num1; //일의 자리
    private GameObject num2; //십의 자리
    float xn = -7f;
    float yn = 1.3f;
    float dis = 0.25f;

    public GameObject ef;

    //배경
    public GameObject Background;
    public GameObject Background2;
    public GameObject Background3;
    public GameObject floor;
    public GameObject floor2;
    public GameObject floor3;
    bool f; //배경 움직임 변수

    bool end; //게임 실패 변수

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

    void Start() //게임 시작 초기화
    {
        audioSource = GetComponent<AudioSource>();/////
        animator = GetComponent<Animator>();

        heart = 100;

        move = 0;
        tremble = false;
        movey = 0;

        healmode = false;

        num1 = Instantiate(number, new Vector2(xn, yn), transform.rotation);
        num2 = Instantiate(number, new Vector2(xn, yn), transform.rotation);
        num1.SetActive(false);
        num2.SetActive(false);

        Background.transform.position = new Vector2(0, Background.transform.position.y);
        f = false;
        
        end = false;
    }

    void FixedUpdate()
    {
        if (movey == 1) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x - speed1 * Time.deltaTime, transform.position.y);
        else if (movey == 2) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x + speed1 * Time.deltaTime, transform.position.y);

        if (move == 1 && transform.position.x < 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), Time.deltaTime * speed);
        }

        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);

        ef.transform.position = new Vector2(transform.position.x + 2.5f, transform.position.y + 2.5f);

        if (move == 2 && transform.position.x > -7)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-7, transform.position.y), Time.deltaTime * (speed + 2));
            Background.transform.position = new Vector2(Background.transform.position.x - (speed + 2) * Time.deltaTime, Background.transform.position.y);
        }

        if (transform.position.x >= 0 && f == false)
        {
            Background.transform.position = new Vector2(Background.transform.position.x - (speed + 2) * Time.deltaTime, Background.transform.position.y);
        }

        Background2.transform.position = new Vector2(Background.transform.position.x + 54.8f, Background.transform.position.y);
        Background3.transform.position = new Vector2(Background.transform.position.x + 109.6f, Background.transform.position.y);

        floor.transform.position = new Vector2(Background.transform.position.x, floor.transform.position.y);
        floor2.transform.position = new Vector2(Background2.transform.position.x, floor2.transform.position.y);
        floor3.transform.position = new Vector2(Background3.transform.position.x, floor3.transform.position.y);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && stage.GetComponent<Stage3>().fortime == 1 && stage.GetComponent<Stage3>().pausemode == false && stage.GetComponent<Stage3>().stage < 2 && GameObject.Find("ending").GetComponent<endingscene>().ending == false)
        {
            CastRay();

            if (target == this.gameObject && healmode == false) //힐모드 시작
            {
                animator.SetBool("heal", true);
                punch.GetComponent<PunchScript>().re();
                punch.GetComponent<PunchScript>().ScrollChange2();
                punch.GetComponent<PunchScript>().punchmode = 2;
                punch.GetComponent<PunchScript>().PunchMode();
                setting();
                healmode = true;
            }
            else if ((target == this.gameObject || target == num1 || target == num2) && healmode == true) //힐모드 종료
            {
                animator.SetBool("heal", false);
                if (punch.GetComponent<PunchScript>().result == random) //난수 = 결과 일치
                {
                    if (heart + random < 100)
                        heart += random;
                    else
                        heart = 100;
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                    PlaySound("healsuccess");/////////////소리
                }
                else //난수 = 결과 불일치
                {
                    if (tremble == false)
                        Tremble();
                    num1.SetActive(false);
                    num2.SetActive(false);
                    random = 0;
                    punch.GetComponent<PunchScript>().re();
                    punch.GetComponent<PunchScript>().ScrollChange2();
                    PlaySound("error");/////////////소리
                    Handheld.Vibrate();
                }
                punch.GetComponent<PunchScript>().punchmode = 1;
                punch.GetComponent<PunchScript>().PunchMode();
                healmode = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().going == 1) //임의 피격
        {
            animator.SetTrigger("attack");
            AttackEffect();
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().who1 = 1;
            GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().num1setting();
        }

        if (tremble == true)
        {
            if (transform.position.x >= x1)
                movey = 1;
            else if (transform.position.x <= x0)
                movey = 2;
        }

        if (heart <= 0 && end == false) //실패
        {
            end = true;
            GameObject.Find("ending").GetComponent<endingscene>().Playerpowerend();
        }
    }

    public void AttackEffect()
    {
        ef.GetComponent<Animator>().SetTrigger("effect");
    }

    void setting() //난수 설정
    {
        random = Random.Range(5, 10);
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

            num1.transform.position = new Vector2(xn + dis, yn);
            num1.SetActive(true);
            num2.SetActive(true);
        }
        else if (random > 0 && random <= 9) //난수가 일의 자리일 때
        {
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[random];

            num1.transform.position = new Vector2(xn, yn);
            num1.SetActive(true);
            num2.SetActive(false);
        }
    }

    void Tremble() //덜덜 함수
    {
        CancelInvoke("Stop");
        x0 = transform.position.x;
        x1 = x0 + 0.1f;

        movey = 1;
        tremble = true;

        Invoke("Stop", 0.35f);
    }
    void Stop() //덜덜 멈추는 함수
    {
        movey = 0;
        transform.position = new Vector2(x0, transform.position.y);
        tremble = false;
    }

    public void HealStop()
    {
        animator.SetBool("heal", false);
        num1.SetActive(false);
        num2.SetActive(false);
        random = 0;
        punch.GetComponent<PunchScript>().re();
    }

    //스테이지 이동
    public void Run() //이동 대기 함수
    {
        Invoke("Run_", 1f);
    }
    void Run_() //애니메이션 미리
    {
        animator.SetBool("walk", true);
        Invoke("RunM", 0.6f);
    }
    void RunM() //중간으로 이동 함수
    {
        move = 1;
        Invoke("Find", 5f);
    }
    void Find() //몬스터 마주침! 함수
    {
        move = 0;
        f = true;
        animator.SetBool("walk", false);
        if (stage.GetComponent<Stage3>().stage < 2)
        {
            animator.SetTrigger("surprise");
        }
        Invoke("Re", 2f);
        PlaySound("opps");
    }
    void Re() //원위치로 이동 함수
    {
        Cul.GetComponent<CulScript>().move1();
        move = 2;
        f = false;
        Invoke("Next", 5f);
        Invoke("soundDong", 1.5f);
        if (stage.GetComponent<Stage3>().stage == 0)
        {
            Invoke("Story1", 2.85f);
        }
    }
    void soundDong(){
        PlaySound("moncome");
    }
    public void Next() //이동 변수 초기화 함수
    {
        move = 0;
    }

    void Story1() //스토리1
    {
        story.GetComponent<Story3Script>().Story1On();
    }
}
