using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBossScript : MonoBehaviour
{
    public int healthbar;
    public GameObject healthbarObject;

    public void healthbar_boss()
    {
        healthbarObject.GetComponent<Slider>().value = healthbar;
    }
}
