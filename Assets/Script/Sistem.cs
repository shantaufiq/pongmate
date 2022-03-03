using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistem : MonoBehaviour
{
    public GameObject motherPopUp;
    public static Sistem instance;
    public int ID;
    public GameObject contentPop;
    public GameObject[] PopUpManager;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ID = 0;
        tampilContent();
    }

    public void tampilContent(){
        GameObject popUpSebelumnya = GameObject.FindGameObjectWithTag("pop-up");
        if (popUpSebelumnya != null) Destroy(popUpSebelumnya); // menghapus pop-up sebelumnya

        GameObject isi = Instantiate(PopUpManager[ID]); // memanggil pop-up pada array
        isi.transform.SetParent(contentPop.transform,false); // memasukkan keadalam parent content
        // Debug.Log("bisa");
        contentPop.GetComponent<Animation>().Play("pop-up"); // memanggil animasi pop-up
    }

    private void Update() {
        // kondisi untuk kontrol keyboard
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            GantiPopUp(true);
        } 
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            GantiPopUp(false);
        } 
    }

    public void GantiPopUp(bool kanan){ // sistem pindah pop-up
        if(kanan){
            if (ID >= PopUpManager.Length - 1){
                ID = 0;
            }else{
                ID++;
            }
        }else{
            if (ID <= 0){
                ID = PopUpManager.Length - 1;
            }else{
                ID--;
            }
        }
        tampilContent();
    }

    // fungsi mematikan pop-up guidelines
    public void MatikanPop(){
        motherPopUp.GetComponent<Animation>().Play("matiinPop");
    }
    public void NyalakanPop(){
        motherPopUp.SetActive(true);
        motherPopUp.GetComponent<Animation>().Play("nyalainPop");
        SuaraManager.instance.PanggilSuara(0);
    }
}
