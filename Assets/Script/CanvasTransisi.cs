using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasTransisi : MonoBehaviour //! transisi pindah scene dengan transisi
{
    private string NamaScene; // local variable untuk menampung nama scene yang mau dituju

    public void btnPindah(string nama) { //! fungsi untuk tombol pindah dengan paramater scene yang dituju
        this.gameObject.SetActive(true);
        NamaScene = nama; // mengubah mengubah local variable dengan NamaScene
        GetComponent<Animator>().Play("end"); //? menjalankan animasi end
    }
    public void MatiinOBJ(){ //! menutup animasi transisi
        this.gameObject.SetActive(false);
    }
    public void NextScene(){ //! pindah scene
        SceneManager.LoadScene(NamaScene);
    }
}
