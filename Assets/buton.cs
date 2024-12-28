using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buton : MonoBehaviour
{
   public void playGame() 
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
