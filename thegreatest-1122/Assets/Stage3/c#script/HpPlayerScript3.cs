using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayerScript3 : MonoBehaviour
{
    public int healthbar;
    
    public GameObject healthbarObject;

    public void healthbar_player()
    {
        healthbar = GameObject.Find("Player").GetComponent<KalScript>().heart;
        healthbarObject.GetComponent<Slider>().value = healthbar;
    }

    void Update() 
    {
        if(GameObject.Find("Player").GetComponent<KalScript>().heart >= 0)
            healthbar_player();
    }
}
