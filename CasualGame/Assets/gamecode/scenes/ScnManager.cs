using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnManager : MonoBehaviour
{
    public string EnterScene, EscapeScene;
    public bool isEscapeToQuit = false;
    public bool useUpdate = false;

    // Update is called once per frame
    void Update()
    {
        if (useUpdate)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                if (SceneManager.GetActiveScene().name == EnterScene)
                {
                    return;
                }

                Debug.Log($"Name scene: {EnterScene}");
                SceneManager.LoadScene(EnterScene);
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (isEscapeToQuit)
                {
                    Debug.Log("Program Quit");
                    Application.Quit();
                }
                else
                {
                    Debug.Log($"Name scene: {EscapeScene}");
                    SceneManager.LoadScene(EscapeScene);
                }
            }
        }
    }

    // Public Event
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
