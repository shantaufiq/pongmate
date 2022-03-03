using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuaraManager : MonoBehaviour
{
    public static SuaraManager instance;
    public AudioClip[] ClipCart;
    [SerializeField]List<AudioSource> suara = new List<AudioSource>();

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        suara.Clear();
        for(int i = 0; i < ClipCart.Length; i++){
            suara.Add(gameObject.AddComponent<AudioSource>());
            suara[i].clip = ClipCart[i];
        }
    }

    public void PanggilSuara(int index){
        suara[index].Play();
        suara[index].volume = 0.5f; //fungsi untuk mengurangi suara
    }
}
