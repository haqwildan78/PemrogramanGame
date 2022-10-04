using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    public string sceneGameOver = "scGameOver";
    public string sceneGameplay = "scGameplay";

    public int MissedChanceCount = 10;

    float timer = 5f, elapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == sceneGameOver)
        {
            // timer on game over screen
            elapsed += Time.deltaTime;
            if (elapsed > timer)
            {
                SceneManager.LoadScene(sceneGameplay);
            }
        }
        else
        {
            // if missed objects passes the chance
            // then go to game over screen
            if (Data.Missed >= MissedChanceCount)
            {
                SceneManager.LoadScene("scGameOver");
            }
        }

        // safe rage quit key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Application Quitting . . . ");
            Application.Quit();
        }
    }
}
