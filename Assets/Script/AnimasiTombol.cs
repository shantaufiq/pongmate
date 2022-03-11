using UnityEngine;

public class AnimasiTombol : MonoBehaviour
{
    public void _Animasi(){ //! animasi tombol dan mengambil suara di SuaraManager.cs
        GetComponent<Animation>().Play("Button"); //? menjalankan aniamsi
        SuaraManager.instance.PanggilSuara(0); //? membanggil sound effect
    }
    public void _AnimasiBtnMenu(){ //! animasi tombol dan mengambil suara di SuaraManager.cs
        GetComponent<Animation>().Play("ButtonMenu"); //? menjalankan aniamsi
        SuaraManager.instance.PanggilSuara(0); //? membanggil sound effect
    }


}
