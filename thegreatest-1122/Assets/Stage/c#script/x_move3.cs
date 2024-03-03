using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class x_move3 : MonoBehaviour
{

    float moveX,moveY;
    [Header("이동속도 조절")]
    [SerializeField][Range(1f,30f)]float moveSpeed=50f;

   public GameObject myslider;

    public float distance=0;
    float speed1=20f;
    private GameObject target;
    public GameObject x_left;
  public GameObject x_right;
    
    


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
        if (Input.GetMouseButton(0))
        {
            CastRay();
            Debug.Log(target);
 
 if(transform.position.x>=70)
        SceneManager.LoadScene("player3Talk");

            if (target == x_left)
            {
              Debug.Log("Left");
              transform.position = new Vector2(transform.position.x - speed1 * Time.deltaTime, transform.position.y);
    
            }
            if (target == x_right)
            {
              Debug.Log("right");
              transform.position = new Vector2(transform.position.x + speed1 * Time.deltaTime, transform.position.y);
            }
        }

       moveX=Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
       moveY=0;//=Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
       
       transform.position=new Vector2(transform.position.x+moveX,transform.position.y+moveY);

    distance=(transform.position.x/85);


        Slider a=myslider.GetComponent<Slider>();
        if (a) {
            a.value= distance;
        }
    }


}

