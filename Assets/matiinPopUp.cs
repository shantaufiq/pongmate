using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matiinPopUp : MonoBehaviour
{
    // Update is called once per frame
    public void setOff()
    {
        this.gameObject.SetActive(false);
    }
    public void setOn()
    {
        this.gameObject.SetActive(true);
    }
}
