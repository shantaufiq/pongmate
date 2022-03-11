using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuaraManager : MonoBehaviour //! menyimpan suara
{
    public static SuaraManager instance;
    public AudioClip[] ClipCart; // bank suara dengan array
    [SerializeField]List<AudioSource> suara = new List<AudioSource>(); // membuat object suara

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        suara.Clear();
        for(int i = 0; i < ClipCart.Length; i++){
            suara.Add(gameObject.AddComponent<AudioSource>()); //? mengambil komponen AudioSource
            suara[i].clip = ClipCart[i]; //? memindahkan playlist ke AudioSource
        }
    }

    public void PanggilSuara(int index){ // fungsi untuk memanggil suara dengan parameter index playlist
        suara[index].Play();
        suara[index].volume = 0.5f; //fungsi untuk mengurangi suara
    }

    public void BacksoundPlay(){ //! memainkan backsound di GamePlay
        this.GetComponent<AudioSource>().Play();
    }
    public void BacksoundOff(){ //! mematikan backsound di GamePlay
        this.GetComponent<AudioSource>().Pause();
    }
}
