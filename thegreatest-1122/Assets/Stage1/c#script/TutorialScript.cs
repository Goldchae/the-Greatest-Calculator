using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject player, playerheal, monster, attackbar, healingbar; //5
    public GameObject timebox, timecount, pause; //3
    public GameObject num1, num2, num3, num4, num5; //5
    public GameObject monheart1, monheart2, monheart3; //3
    public GameObject button1, button2, button3, button4; //4
    public GameObject canvas; //1

    public GameObject background;
    GameObject background1; //1

    public GameObject balloon; //1
    public GameObject arrow1, arrow2, arrow3, arrow4, arrow5, arrow6; //6
    public GameObject Text; //1
    public Text text; //1

    public List<string> sentences;

    float x1 = -5f;
    float y1 = -2f;
    float x2 = -2f;
    float y2 = 1f;
    float y2t = 0.97f;
    float x3 = -1f;
    float y3 = -2f;
    float x4 = 2.3f;
    float y4 = 1.7f;
    float y4t = 1.67f;
    float x5 = 2f;
    float y5 = 1.5f;
    float y5t = 1.48f;
    float x6 = 6.4f;
    float y6 = 2f;
    float y6t = 1.95f;

    int i;
    public bool nextbutton;

    public GameObject realplayer;
    public GameObject resume;

    void Start()
    {
        player.SetActive(false);
        playerheal.SetActive(false);
        monster.SetActive(false);
        attackbar.SetActive(false);
        healingbar.SetActive(false);

        timebox.SetActive(false);
        timecount.SetActive(false);
        pause.SetActive(false);

        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        num4.SetActive(false);
        num5.SetActive(false);

        monheart1.SetActive(false);
        monheart2.SetActive(false);
        monheart3.SetActive(false);

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);

        canvas.SetActive(false);

        background1 = Instantiate(background, transform.position, transform.rotation);
        background1.SetActive(false);

        balloon.SetActive(false);

        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
        arrow5.SetActive(false);
        arrow6.SetActive(false);

        Text.SetActive(false);

        i = 0;
        nextbutton = false;

        sentences = new List<string>();
        sentences.Add("숫자 몬스터입니다. 가까이 다가와 플레이어를 공격합니다."); //5
        sentences.Add("숫자 버튼을 이용하여 몬스터의 수를 완성합니다."); //3
        sentences.Add("해당 몬스터 혹은\n몬스터 위의 숫자를 눌러 공격합니다."); //5
        sentences.Add("버튼은 한 번만 누르고 공격해도 됩니다."); //3
        sentences.Add("연산은 숫자가 999를 넘기 전까지 가능합니다."); //3
        sentences.Add("C 버튼을 누르면 리셋됩니다."); //1
        sentences.Add("체력이 부족할 시 플레이어를 누르면 힐모드가 됩니다."); //2
        sentences.Add("플레이어 머리 위 숫자를 만들고, 다시 플레이어를 누르면 체력이 올라갑니다."); //2
        sentences.Add("힐모드를 종료하고 싶으면 플레이어를 한 번 더 눌러주세요."); //2
        sentences.Add("멈춤 버튼으로 잠시 플레이를 멈출 수 있습니다."); //6
        sentences.Add("시간 안에 클리어하세요. 남은 시간에 따라서 별이 지급됩니다."); //4
    }

    void Update()
    {
        if (nextbutton == true)
        {
            if (i == 10)
            {
                SceneOff();
            }
            else
            {
                i++;
                Scene();
                nextbutton = false;
            }
        }
    }

    public void Scene()
    {
        if (i == 0)
        {
            GameObject.Find("Stage").GetComponent<Stage>().PauseMode();
            GameObject.Find("Stage").GetComponent<Stage>().MusicPauseMode();
            GameObject.Find("Stage").GetComponent<Stage>().tutorial = true;
            realplayer.SetActive(false);
            resume.SetActive(false);

            player.SetActive(true);
            monster.SetActive(true);
            attackbar.SetActive(true);

            timebox.SetActive(false);
            timecount.SetActive(false);
            pause.SetActive(true);

            num1.SetActive(false);
            num2.SetActive(true);
            num3.SetActive(true);
            num4.SetActive(true);
            num5.SetActive(true);

            monheart1.SetActive(true);
            monheart2.SetActive(true);
            monheart3.SetActive(true);

            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button4.SetActive(true);

            canvas.SetActive(true);

            background1.SetActive(true);

            balloon.SetActive(true);

            Text.SetActive(true);

            balloon.transform.position = new Vector2(x5, y5);
            Text.transform.position = new Vector2(x5, y5t);
            text.text = sentences[i];
            arrow5.SetActive(true);

            monster.GetComponent<SpriteRenderer>().sortingOrder = 2;
            monheart1.GetComponent<SpriteRenderer>().sortingOrder = 2;
            monheart2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            monheart3.GetComponent<SpriteRenderer>().sortingOrder = 2;
            num2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            num3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else if (i == 1)
        {
            balloon.transform.position = new Vector2(x3, y3);
            Text.transform.position = new Vector2(x3, y3);
            text.text = sentences[i];
            arrow5.SetActive(false);
            arrow3.SetActive(true);

            attackbar.GetComponent<SpriteRenderer>().sortingOrder = 2;
            num4.GetComponent<SpriteRenderer>().sortingOrder = 2;
            num5.GetComponent<SpriteRenderer>().sortingOrder = 2;
            button1.GetComponent<SpriteRenderer>().sortingOrder = 2;
            button2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            button3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else if (i == 2)
        {
            attackbar.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num4.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num5.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button3.GetComponent<SpriteRenderer>().sortingOrder = 0;
            monheart1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            monheart2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            monheart3.GetComponent<SpriteRenderer>().sortingOrder = 0;

            balloon.transform.position = new Vector2(x5, y5);
            Text.transform.position = new Vector2(x5, y5t);
            text.text = sentences[i];
            arrow3.SetActive(false);
            arrow5.SetActive(true);
        }
        else if (i == 3)
        {
            balloon.transform.position = new Vector2(x3, y3);
            Text.transform.position = new Vector2(x3, y3);
            text.text = sentences[i];
            arrow5.SetActive(false);
            arrow3.SetActive(true);

            attackbar.GetComponent<SpriteRenderer>().sortingOrder = 2;
            num4.GetComponent<SpriteRenderer>().sortingOrder = 2;
            num5.GetComponent<SpriteRenderer>().sortingOrder = 2;
            button1.GetComponent<SpriteRenderer>().sortingOrder = 2;
            button2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            button3.GetComponent<SpriteRenderer>().sortingOrder = 2;
            monheart1.GetComponent<SpriteRenderer>().sortingOrder = 2;
            monheart2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            monheart3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else if (i == 4)
        {
            monster.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num3.GetComponent<SpriteRenderer>().sortingOrder = 0;
            monheart1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            monheart2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            monheart3.GetComponent<SpriteRenderer>().sortingOrder = 0;

            text.text = sentences[i];
        }
        else if (i == 5)
        {
            attackbar.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num4.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num5.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button3.GetComponent<SpriteRenderer>().sortingOrder = 0;

            balloon.transform.position = new Vector2(x1, y1);
            Text.transform.position = new Vector2(x1, y1);
            text.text = sentences[i];
            arrow3.SetActive(false);
            arrow1.SetActive(true);

            button4.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else if (i == 6)
        {
            player.SetActive(false);
            playerheal.SetActive(true);
            attackbar.SetActive(false);
            healingbar.SetActive(true);
            num1.SetActive(true);
            num4.SetActive(false);
            num5.SetActive(false);

            player.GetComponent<SpriteRenderer>().sortingOrder = 0;
            attackbar.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num4.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num5.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button4.GetComponent<SpriteRenderer>().sortingOrder = 0;

            balloon.transform.position = new Vector2(x2, y2);
            Text.transform.position = new Vector2(x2, y2t);
            text.text = sentences[i];
            arrow1.SetActive(false);
            arrow2.SetActive(true);

            playerheal.GetComponent<SpriteRenderer>().sortingOrder = 2;
            healingbar.GetComponent<SpriteRenderer>().sortingOrder = 2;
            num1.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else if (i == 7)
        {
            text.text = sentences[i];

            button1.GetComponent<SpriteRenderer>().sortingOrder = 2;
            button2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            button3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else if (i == 8)
        {
            healingbar.GetComponent<SpriteRenderer>().sortingOrder = 0;
            num1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button2.GetComponent<SpriteRenderer>().sortingOrder = 0;
            button3.GetComponent<SpriteRenderer>().sortingOrder = 0;

            text.text = sentences[i];
        }
        else if (i == 9)
        {
            num1.SetActive(false);
            player.SetActive(true);
            playerheal.SetActive(false);
            attackbar.SetActive(false);
            healingbar.SetActive(false);

            balloon.transform.position = new Vector2(x6, y6);
            Text.transform.position = new Vector2(x6, y6t);
            text.text = sentences[i];
            arrow2.SetActive(false);
            arrow6.SetActive(true);

            pause.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else if (i == 10)
        {
            timebox.SetActive(true);
            timecount.SetActive(true);

            pause.GetComponent<SpriteRenderer>().sortingOrder = 0;

            balloon.transform.position = new Vector2(x4, y4);
            Text.transform.position = new Vector2(x4, y4t);
            text.text = sentences[i];
            arrow6.SetActive(false);
            arrow4.SetActive(true);

            timebox.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
    
    void SceneOff()
    {
        GameObject.Find("Stage").GetComponent<Stage>().ResumeMode();
        GameObject.Find("Stage").GetComponent<Stage>().MusicResumeMode();
        GameObject.Find("Stage").GetComponent<Stage>().tutorial = false;
        realplayer.SetActive(true);

        Destroy(gameObject);
        Destroy(canvas);
        Destroy(background1);
    }
}