using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayerScript : MonoBehaviour
{
    public int healthbar;
    
    public GameObject healthbarObject;

    public void healthbar_player()
    {
        healthbar = GameObject.Find("Player").GetComponent<PlayerScript>().heart;
        healthbarObject.GetComponent<Slider>().value = healthbar;
    }

    void Update() 
    {
        if(GameObject.Find("Stage").GetComponent<Stage>().tutorial == false)
        {
            if(GameObject.Find("Player").GetComponent<PlayerScript>().heart >= 0)
                healthbar_player();
        }
    }
}
