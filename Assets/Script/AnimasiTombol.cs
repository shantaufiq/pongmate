using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiTombol : MonoBehaviour
{
    public void _Animasi(){ //! animasi tombol dan mengambil suara di SuaraManager.cs
        GetComponent<Animation>().Play("Button"); //? menjalankan aniamsi
        SuaraManager.instance.PanggilSuara(0); //? membanggil sound effect
    }
}
