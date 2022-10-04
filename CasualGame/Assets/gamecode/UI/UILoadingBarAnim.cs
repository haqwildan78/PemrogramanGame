using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoadingBarAnim : MonoBehaviour
{
    [SerializeField] private float loadingDelay = 2f;
    private float timeElapsed;

    public string sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > loadingDelay)
        {
            if (!string.IsNullOrWhiteSpace(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else Debug.Log("SceneToLoad is empty.");
        }
    }
}
