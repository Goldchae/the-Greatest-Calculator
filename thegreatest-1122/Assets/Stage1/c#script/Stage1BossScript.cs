using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1BossScript : MonoBehaviour
{
    AudioSource audioSource;/////////////소리
    public AudioClip bombsound;
    public AudioClip bombgogo; //타는소리
    public AudioClip logcome;

    void PlaySound(string action){
        switch (action){
            case "bombsound":
                audioSource.clip = bombsound;
                break;
            case "bombgogo":
                audioSource.clip = bombgogo;
                break;
            case "logcome":
                audioSource.clip = logcome;
                break;
        }
        audioSource.Play();
    }

    public Animator animator;

    public int heart; //몬스터 체력

    private bool move;
    private int movey; //몬스터 이동 변수2
    private bool tremble; //몬스터 ㅂㄷㅂㄷ 변수

    //몬스터 이동 관련
    float speed;
    public float xm;

    //몬스터 ㅂㄷㅂㄷ 관련
    float speed2 = 5f;
    float time;
    float x0;
    float x1;

    public int random;

    //난수 표시 관련
    public GameObject number;
    private GameObject num1; //일의 자리
    private GameObject num2; //십의 자리
    float dis = 0.3f;

    public bool skill1;
    public bool skill2;
    bool damaged;

    public GameObject bomb;
    public GameObject bom;
    public Image bombtimer;

    public float timemax = 10f;
    public float time1;
    bool timer;

    public GameObject e3;
    public GameObject e4;
    private GameObject ef3;
    private GameObject ef4;

    //폭탄
    int bombmove; //0 기본, 1 소환, 2 공격, 3 피격
    float speed3 = 4f;
    float speed4 = 7f;

    public GameObject canvas;

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

    void Start() //스폰
    {
        audioSource = GetComponent<AudioSource>();/////////////소리
        animator = GetComponent<Animator>();

        heart = 5;

        xm = 7f;
        move = false;
        speed = 2f;
        movey = 1;
        tremble = false;

        skill1 = true;
        skill2 = false;
        damaged = true;

        bombmove = 0;
        timer = false;
        time1 = timemax;

        ef3 = Instantiate(e3, transform.position, transform.rotation);
        ef4 = Instantiate(e4, transform.position, transform.rotation);

        bom = Instantiate(bomb, new Vector2(transform.position.x, -2), transform.rotation);
        num1 = Instantiate(number, new Vector2(bom.transform.position.x - dis, bom.transform.position.y), transform.rotation);
        num2 = Instantiate(number, new Vector2(bom.transform.position.x, bom.transform.position.y), transform.rotation);

        bom.SetActive(false);
        num1.SetActive(false);
        num2.SetActive(false);
    }

    public void Run() //리스폰
    {
        speed = 5f;
        move = true;
    }

    void FixedUpdate()
    {
        if (transform.position.x > xm && move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xm, transform.position.y), Time.deltaTime * speed);
        }

        if (movey == 4) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x - speed2 * Time.deltaTime, transform.position.y);
        else if (movey == 5) //ㅂㄷㅂㄷ
            transform.position = new Vector2(transform.position.x + speed2 * Time.deltaTime, transform.position.y);

        if (movey == 6) //안녕히계세요~
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xm + 7, transform.position.y), Time.deltaTime * (speed - 2));
            transform.localScale = new Vector3(-0.9f, 0.9f, 1);
        }

        if (random > 9 && random <= 99) //십의 자리일 때
        {
            num1.transform.position = new Vector2(bom.transform.position.x + dis, bom.transform.position.y);
        }
        else if (random > 0 && random <= 9) //일의 자리일 때
        {
            num1.transform.position = new Vector2(bom.transform.position.x, bom.transform.position.y);
        }
        num2.transform.position = new Vector2(num1.transform.position.x - 2 * dis, num1.transform.position.y);

        ef3.transform.position = new Vector2(transform.position.x - 4f, transform.position.y);
        ef4.transform.position = new Vector2(transform.position.x - 4f, transform.position.y);

        if (bombmove == 1)
            bom.transform.position = Vector3.Slerp(bom.transform.position, new Vector2(3.4f, 0), Time.deltaTime * speed3);

        if (bombmove == 2)
            bom.transform.position = Vector3.Lerp(bom.transform.position, new Vector2(-4f, -1), Time.deltaTime * speed4);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Stage").GetComponent<Stage>().pausemode == false)
        {
            CastRay();

            if ((target == num1 || target == num2 || target == bom) && GameObject.Find("Punch").GetComponent<PunchScript>().punchmode == 1)
            {
                if (GameObject.Find("Punch").GetComponent<PunchScript>().result == random && time1 > 0) //난수 = 결과 일치
                {
                    timer = false;

                    GameObject.Find("Stage").GetComponent<Stage>().xf = bom.transform.position.x;
                    GameObject.Find("Stage").GetComponent<Stage>().yf = bom.transform.position.y;

                    GameObject.Find("Stage").GetComponent<Stage>().Fly1();

                    GameObject.Find("Punch").GetComponent<PunchScript>().punchmode = 0;
                    GameObject.Find("Punch").GetComponent<PunchScript>().PunchMode();

                    GameObject.Find("Punch").GetComponent<PunchScript>().re();

                    GameObject.Find("Stage").GetComponent<Stage>().BombOff();
                }
            }
        }
        
        if (tremble == true)
        {
            if (transform.position.x >= x1)
                movey = 4;
            else if (transform.position.x <= x0)
                movey = 5;
        }
        
        if (heart == 4 && damaged == false)
        {
            Invoke("Skill_2", 1f);
            damaged = true;
        }
        if (heart == 3 && damaged == false)
        {
            Invoke("Skill_2", 1f);
            damaged = true;
        }
        if (heart == 2 && damaged == false)
        {
            Invoke("Skill_2", 1f);
            damaged = true;
        }
        if (heart == 1 && damaged == false)
        {
            Invoke("story2_2", 1.5f);
            Invoke("Skill_2", 2f);
            damaged = true;
        }
        if (heart == 0 && damaged == false)
        {
            GameObject.Find("Canvas").GetComponent<HpBossScript>().healthbar = heart;
            GameObject.Find("Canvas").GetComponent<HpBossScript>().healthbar_boss();
            Invoke("story3", 1.5f);
            Invoke("Die", 3f);
            damaged = true;
            GameObject.Find("Stage").GetComponent<Stage>().fortime = 0;
        }

        if (skill1 == false && skill2 == false && GameObject.Find("Stage").GetComponent<Stage>().remain == 1)
        {
            bom.transform.position = new Vector2(transform.position.x, -2);
            Invoke("story2_1", 1.5f);
            Invoke("Skill_2", 2f);
            damaged = false;
            skill2 = true;
        }

        if (bombmove == 1 && bom.transform.position.x <= 3.5f)
        {
            timer = true;
            setting();
            bom.GetComponent<Animator>().SetTrigger("bomb");
            PlaySound("bombgogo"); ////////소리
            bombmove = 0;
        }
        if (bombmove == 2 && bom.transform.position.x <= -3.9f)
        {
            bom.GetComponent<Animator>().SetTrigger("bombdestroy");
            Invoke("Attack", 0.47f);
            PlaySound("bombsound"); ////////소리
            Handheld.Vibrate();
            bombmove = 0;
        }

        if (timer == true)
        {
            time1 -= Time.deltaTime;
            GameObject.Find("Stage").GetComponent<Stage>().BombTimer();
            GameObject.Find("Stage").GetComponent<Stage>().xb = bom.transform.position.x;
            GameObject.Find("Stage").GetComponent<Stage>().yb = bom.transform.position.y;
            GameObject.Find("Stage").GetComponent<Stage>().BombPosition();
        }

        if (time1 <= 0)
        {
            bombmove = 2;
            GameObject.Find("Stage").GetComponent<Stage>().BombOff();
            animator.SetTrigger("stage1bossattack");
            ef3.GetComponent<Animator>().SetTrigger("effect3");
            ef4.GetComponent<Animator>().SetTrigger("effect4");
            num1.SetActive(false);
            num2.SetActive(false);
            time1 = timemax;
            timer = false;
        }

        if(heart >= 0 && GameObject.Find("Stage").GetComponent<Stage>().fortime == 1)
        {
            GameObject.Find("Canvas").GetComponent<HpBossScript>().healthbar = heart;
            GameObject.Find("Canvas").GetComponent<HpBossScript>().healthbar_boss();
        }

        if (GameObject.Find("ending").GetComponent<endingscene>().ending == true)
        {
            AllStop();
        }
    }

    private void setting() //난수 설정
    {
        random = Random.Range(20, 31);
        nummaker();
    }

    void nummaker()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("number");
        if (random > 9 && random <= 99) //십의 자리일 때
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
        else if (random > 0 && random <= 9) //일의 자리일 때
        {
            SpriteRenderer spriteA = num1.GetComponent<SpriteRenderer>();
            spriteA.sprite = sprites[random];

            num1.SetActive(true);
            num2.SetActive(false);
        }
    }

    void Tremble() //덜덜 함수
    {
        CancelInvoke("Stop");
        x0 = gameObject.transform.position.x;
        x1 = x0 + 0.1f;
        tremble = true;
        Invoke("Stop", 0.35f);
    }
    void Stop()
    {
        movey = 1;
        transform.position = new Vector2(x0, transform.position.y);
        tremble = false;
    }

    void Skill_1()
    {
        GameObject.Find("Stage").GetComponent<Stage>().Boss1Skill();
    }
    void Skill_2()
    {
        bom.SetActive(true);
        bombmove = 1;
    }

    void Attack()
    {
        GameObject.Find("Player").GetComponent<PlayerScript>().heart -= 10;
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hit");
        GameObject.Find("Punch").GetComponent<PunchScript>().re();
        GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();

        bom.transform.position = new Vector2(transform.position.x, -2);
        bom.SetActive(false);

        Invoke("Skill_2", 1f);
    }

    public void OnDamaged()
    {
        num1.SetActive(false);
        num2.SetActive(false);
        bom.GetComponent<Animator>().SetTrigger("bombdestroy");
        Invoke("realOnDamaged", 0.46f);
    }
    void realOnDamaged()
    {
        bom.transform.position = new Vector2(transform.position.x, -2);
        bom.SetActive(false);

        Tremble();
        time1 = timemax;
        GameObject.Find("Punch").GetComponent<PunchScript>().re();
        GameObject.Find("Punch").GetComponent<PunchScript>().ScrollChange2();
        animator.SetTrigger("stage1bosshit");
        heart--;
        damaged = false;
        PlaySound("bombsound"); ////////소리
        Handheld.Vibrate();
    }

    void story2_1()
    {
        GameObject.Find("Story").GetComponent<StoryScript>().Story2_1On();
    }
    void story2_2()
    {
        GameObject.Find("Story").GetComponent<StoryScript>().Story2_2On();
    }
    void story3()
    {
        GameObject.Find("Story").GetComponent<StoryScript>().Story3On();
    }

    void Die() //죽음 처리 함수
    {
        GameObject.Find("Stage").GetComponent<Stage>().BossHealthbarOff();
        GameObject.Find("Stage").GetComponent<Stage>().remain -= 1;
        Destroy(gameObject);
        Destroy(bom);
        Destroy(num1);
        Destroy(num2);

        GameObject.Find("Player").GetComponent<PlayerScript>().xb = transform.position.x;
        GameObject.Find("Player").GetComponent<PlayerScript>().yb = transform.position.y;
        GameObject.Find("Player").GetComponent<PlayerScript>().bm();
    }

    void AllStop()
    {
        CancelInvoke("Skill_2");
        move = false;
        if (GameObject.Find("ending").GetComponent<endingscene>().endingnum != 1)
        {
            movey = 6;
        }
    }
}