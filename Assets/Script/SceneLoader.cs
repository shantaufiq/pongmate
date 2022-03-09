using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneLoader : MonoBehaviour // fungsi pindah scene
{
    public void ChangeScene(string NamaScene){ // berupa string
        
        SceneManager.LoadScene(NamaScene);
    }
    public void ChangeScene(int IndexScene){ // berupa index
        SceneManager.LoadScene(IndexScene);
    }
    public void ReloadScene(){ // reload scene 
        string perintah = "reload";
        StartCoroutine(WaitaMinute(perintah));
    }

    IEnumerator WaitaMinute(string perintah){ // fungsi reload dengan delay 0.7 float

        yield return new WaitForSecondsRealtime(0.7f);

        switch(perintah){
            case "reload":
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
            break;
            default:
            break;
        }
    }
}
