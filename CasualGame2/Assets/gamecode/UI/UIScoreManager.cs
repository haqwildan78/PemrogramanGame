using UnityEngine;
using UnityEngine.UI;

public class UIScoreManager : MonoBehaviour
{
    public Text uiScore, uiMissed, uiWrong;

    // Start is called before the first frame update
    void Start()
    {
        Data.ResetData();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        uiScore.text = Data.Score.ToString();
        uiMissed.text = Data.Missed.ToString();
        uiWrong.text = Data.Wrong.ToString();
    }
}
