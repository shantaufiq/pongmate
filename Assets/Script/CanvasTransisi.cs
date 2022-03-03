using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasTransisi : MonoBehaviour // transisi pindah scene
{
    private string NamaScene; // nama scene yang mau dituju

    public void btnPindah(string nama) {
        this.gameObject.SetActive(true);
        NamaScene = nama;
        GetComponent<Animator>().Play("end");
        
    }
    public void MatiinOBJ(){
        this.gameObject.SetActive(false);
    }
    public void NextScene(){
        SceneManager.LoadScene(NamaScene);
    }
}
