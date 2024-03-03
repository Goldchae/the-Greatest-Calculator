using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public GameObject background, playerimage, bossimage, textbox, nextbutton, canvas;
    GameObject background1, playerimage1, bossimage1, textbox1, nextbutton1;
    
    public Text storytext;

    public List<string> sentences1;
    public List<string> sentences1_2;
    public List<string> sentences2;
    public List<string> sentences2_1;
    public List<string> sentences2_2;
    public List<string> sentences3;
    public bool clickNextButton = false;

    int size, i, s;

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

    void Start()
    {
        background1 = Instantiate(background, background.transform.position, transform.rotation);
        playerimage1 = Instantiate(playerimage, playerimage.transform.position, transform.rotation);
        bossimage1 = Instantiate(bossimage, bossimage.transform.position, transform.rotation);
        textbox1 = Instantiate(textbox, textbox.transform.position, transform.rotation);
        nextbutton1 = Instantiate(nextbutton, nextbutton.transform.position, transform.rotation);

        canvas.SetActive(false);
        background1.SetActive(false);
        playerimage1.SetActive(false);
        bossimage1.SetActive(false);
        textbox1.SetActive(false);
        nextbutton1.SetActive(false);
    }

    void Update()
    {
        if (clickNextButton == true && GameObject.Find("Stage").GetComponent<Stage>().story != 0)
        {
            i++;
            if (i == size)
            {
                StoryOff();
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 1)
            {
                if (i == 1)
                {
                    s = 0;
                    SpriteChange();
                }
                
                storytext.text = sentences1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 1.5f)
            {
                if (i == 1)
                {
                    s = 13;
                    SpriteChange();
                }

                storytext.text = sentences1_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 2)
            {
                if (i == 4 || i == 5 || i == 8 || i == 9)
                {
                    Storylog10();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 2.1f)
            {
                if (i == 1 || i == 2)
                {
                    Storylog10();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2_1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 2.5f)
            {
                if (i == 2)
                {
                    s = 2;
                    SpriteChange();
                    Storylog10();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage>().story == 3)
            {
                if (i == 2 || i == 3)
                {
                    Storylog10();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences3[i];
                clickNextButton = false;
            }
        }
    }

    public void Story1On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 1;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1 = new List<string>();
        sentences1.Add("...!");
        sentences1.Add("그새 어디로 사라진 거야?!");
        sentences1.Add("그나저나 오는 길이 무너져가는 빙하일 줄은 몰랐어...");
        sentences1.Add("이럴 줄 알았으면 점프 훈련 때 늦잠자지 말 걸!");
        sentences1.Add("먼 앞쪽에서 강한 악한 기운이 느껴진다.");
        sentences1.Add("한번 나아가보자.");
        size = sentences1.Count;

        s = 12;
        SpriteChange();
        s = 1;
        SpriteChange();
        i = 0;
        storytext.text = sentences1[i];
    }
    public void Story1_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 1.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1_2 = new List<string>();
        sentences1_2.Add("이런, 처음 보는 괴물들이잖아!");
        sentences1_2.Add("마찬가지로 큘의 부하들인가? 하는 수 없군. 내가 전부 혼쭐을 내주지!");
        size = sentences1_2.Count;

        s = 0;
        SpriteChange();
        s = 1;
        SpriteChange();
        i = 0;
        storytext.text = sentences1_2[i];
    }

    public void Story2On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 2;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2 = new List<string>();
        //0, 4, 5, 8, 9
        sentences2.Add("이런! 벌써 여기까지 와 버리다니! 우리 기사들을 다 처리해버린 것인가?!"); //로그십
        sentences2.Add("(드디어 제대로 조우했군.)"); //칼
        sentences2.Add("그렇습니다. 대체 평화롭던 얼음 마을을 왜 공격한 겁니까?"); //칼
        sentences2.Add("당신 때문에 수많은 주민들이 고통받고 있습니다!"); //칼
        sentences2.Add("글쎄? 단지 우린 이 마을에 혁명을 일으킨 거라네!"); //로그십
        sentences2.Add("모두들 미적미적대는 꼴은 정말 봐줄 수 없어... 자넨 이런 내 신념을 이해할 수 있겠나?"); //로그십
        sentences2.Add("(제정신이 아니잖아...?)"); //칼
        sentences2.Add("칼의 뜻을 따르게 된 걸 후회하게 될 것입니다."); //칼
        sentences2.Add("감히 그 분을 언급하다니! 역시 너 따윈 절대 우리의 위대한 긍지를 이해할 수 없어!"); //로그십
        sentences2.Add("나의 1:2, 3:2 정수 비의 이상적 화음 기사단을 보게나!"); //로그십
        size = sentences2.Count;

        s = 0;
        SpriteChange();
        s = 1;
        SpriteChange();
        Storylog10();
        i = 0;
        storytext.text = sentences2[i];
    }
    public void Story2_1On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 2.1f;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2_1 = new List<string>();
        //1, 2
        sentences2_1.Add("이게 다인가요?"); //칼
        sentences2_1.Add("그럴리가! 이번엔 내 차례라네."); //로그십
        sentences2_1.Add("내 공격은 조금 다를걸세!"); //로그십
        size = sentences2_1.Count;

        s = 0;
        SpriteChange();
        s = 1;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences2_1[i];
    }
    public void Story2_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 2.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2_2 = new List<string>();
        //2
        sentences2_2.Add("더 이상의 악행을 멈추겠다 약속하세요!"); //칼
        sentences2_2.Add("그럼 저도 더 이상 당신을 공격하지 않을 것입니다!"); //칼
        sentences2_2.Add("헛소리는 집어치워!"); //로그십
        size = sentences2_2.Count;

        s = 0;
        SpriteChange();
        s = 1;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences2_2[i];
    }

    public void Story3On()
    {
        GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 3f;

        canvas.SetActive(true);
        background1.SetActive(true);
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences3 = new List<string>();
        //0, 2, 3
        sentences3.Add("으윽..."); //로그십
        sentences3.Add("...대체 무엇이 당신을 이렇게까지 만든 겁니까."); //칼
        sentences3.Add("말했잖아. 너 따윈 절대로 이해할 수 없다고..."); //로그십
        sentences3.Add("방심하지 마. 내가 없어도 이 싸움은 계속될걸세..."); //로그십
        size = sentences3.Count;

        s = 0;
        SpriteChange();
        s = 3;
        SpriteChange();
        Storylog10();
        i = 0;
        storytext.text = sentences3[i];
    }

    void Storykal()
    {
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
    }
    void Storylog10()
    {
        playerimage1.SetActive(false);
        bossimage1.SetActive(true);
    }

    public void SpriteChange()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("story");
        SpriteRenderer spriteA = playerimage1.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteB = bossimage1.GetComponent<SpriteRenderer>();
        if (s == 0)
        {
            spriteA.sprite = sprites[s];
        }
        else if (s == 1)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 2)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 3)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 4)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 5)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 6)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 7)
        {
            spriteA.sprite = sprites[s];
        }
        else if (s == 8)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 9)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 10)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 11)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 12)
        {
            spriteA.sprite = sprites[s];
        }
        else if (s == 13)
        {
            spriteA.sprite = sprites[s];
        }
    }

    public void StoryOff()
    {
        GameObject.Find("Stage").GetComponent<Stage>().ResumeMode();
        GameObject.Find("Stage").GetComponent<Stage>().story = 0;

        canvas.SetActive(false);
        background1.SetActive(false);
        playerimage1.SetActive(false);
        bossimage1.SetActive(false);
        textbox1.SetActive(false);
        nextbutton1.SetActive(false);

        clickNextButton = false;
    }
}