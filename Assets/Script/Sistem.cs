using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistem : MonoBehaviour //! fungsi untuk megatur sistem pada main-menu
{
    public static Sistem instance;
    public GameObject motherPopUp; //! mengambil mother element untuk ditampilkan
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

    private void Update() {
        // kondisi untuk kontrol keyboard
        if(Input.GetKeyDown(KeyCode.RightArrow)){ // ketika menekan RightArrow maka akan next ke selanjutnya
            GantiPopUp(true);
        } 
        if(Input.GetKeyDown(KeyCode.LeftArrow)){ // ketika menekan LeftArrow maka akan next ke sebelumnya
            GantiPopUp(false);
        } 
    }

public void tampilContent(){ //! fungsi menampilkan pop-up
        GameObject popUpSebelumnya = GameObject.FindGameObjectWithTag("pop-up");
        if (popUpSebelumnya != null) Destroy(popUpSebelumnya); // menghapus pop-up sebelumnya

        GameObject isi = Instantiate(PopUpManager[ID]); // memanggil pop-up pada array
        isi.transform.SetParent(contentPop.transform,false); // memasukkan keadalam parent content
        // Debug.Log("bisa");
        contentPop.GetComponent<Animation>().Play("pop-up"); // memanggil animasi pop-up
    }

    public void GantiPopUp(bool kanan){ //! sistem pindah pop-up
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

    public void MatikanPop(){ //! fungsi mematikan pop-up guidelines dengan animasi
        motherPopUp.GetComponent<Animation>().Play("matiinPop");
    }
    public void NyalakanPop(){ //! fungsi menyalakan pop-up guidelines dengan animasi
        motherPopUp.SetActive(true);
        motherPopUp.GetComponent<Animation>().Play("nyalainPop");
        SuaraManager.instance.PanggilSuara(0);
    }
}
