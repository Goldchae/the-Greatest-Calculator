using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playername : MonoBehaviour
{
    public GameObject input;

    private void OnMouseDown() 
    {
        input.SetActive(false);
    }

}
