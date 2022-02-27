using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string NamaScene){
        
        SceneManager.LoadScene(NamaScene);
    }
    public void ChangeScene(int IndexScene){
        SceneManager.LoadScene(IndexScene);
    }
    public void ReloadScene(){
        string perintah = "reload";
        StartCoroutine(WaitaMinute(perintah));
    }

    IEnumerator WaitaMinute(string perintah){

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
