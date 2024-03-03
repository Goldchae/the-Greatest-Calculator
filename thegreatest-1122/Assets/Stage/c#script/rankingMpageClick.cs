using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankingMpageClick : MonoBehaviour
{
    public GameObject Total;
    public GameObject Monthtext;

    private void OnMouseDown() 
    {
        Total.SetActive(false);
        Monthtext.SetActive(false);
    }
}
