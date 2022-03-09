using UnityEngine;

public class matiinPopUp : MonoBehaviour // Animasi Pop-up di main menu
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
