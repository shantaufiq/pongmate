using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiTombol : MonoBehaviour
{
    public void _Animasi(){
        GetComponent<Animation>().Play("Button");
        SuaraManager.instance.PanggilSuara(0);
    }
}
