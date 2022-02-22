using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string NamaScene){
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(NamaScene);
    }
    public void ChangeScene(int IndexScene){
        SceneManager.LoadScene(IndexScene);
    }
}
