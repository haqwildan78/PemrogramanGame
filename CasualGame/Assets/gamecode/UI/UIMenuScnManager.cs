using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuScnManager : MonoBehaviour
{
    public string urlMenuScene, urlLoadingScene, urlCreditScene;

    //Main Menu Events
    public void MenuScene()
    {
        if (!string.IsNullOrWhiteSpace(urlMenuScene))
        {
            SceneManager.LoadScene(urlMenuScene);
        }
        else Debug.Log("urlMenuScene is empty.");
    }
    public void LoadingScene()
    {
        if(!string.IsNullOrWhiteSpace(urlLoadingScene))
        {
            SceneManager.LoadScene(urlLoadingScene);
        }
        else Debug.Log("urlLoadingScene is empty.");
    }
    public void CredicScene()
    {
        if (!string.IsNullOrWhiteSpace(urlCreditScene))
        {
            SceneManager.LoadScene(urlCreditScene);
        }
        else Debug.Log("urlCreditScene is empty.");
    }
    public void KeluarGame()
    {
        Debug.Log("Program Quit");
        Application.Quit();
    }
}
