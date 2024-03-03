using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightBarScript : MonoBehaviour
{
    public int fighthbar;
    bool once;
    
    public GameObject fighthbarObject;

    void Start()
    {
        once = false;
        fighthbar = 5;
        fighthbarObject.GetComponent<Slider>().value = 5;
    }

    void Update() 
    {
        if(GameObject.Find("NumberBundle").GetComponent<NumberBundleScript>().going == 1)
            fighthbarObject.GetComponent<Slider>().value = fighthbar;

        if (fighthbarObject.GetComponent<Slider>().value >= 10 && once == false)
        {
            GameObject.Find("Stage").GetComponent<Stage3>().Win();
            once = true;
        }

        if (fighthbarObject.GetComponent<Slider>().value <= 0 && once == false)
        {
            GameObject.Find("Stage").GetComponent<Stage3>().Lose();
            once = true;
        }
    }
}
