using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsManager : MonoBehaviour
{
    public Text textAudioPercent;
    public Dropdown dropdownResolution;
    public Slider SliderVolume;
    public Toggle FullScreenToggle;

    Resolution[] resolutionList;
    int currentResolutionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        FullScreenToggle.isOn = Screen.fullScreen;

        resolutionList = Screen.resolutions;
        dropdownResolution.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutionList.Length; i++)
        {
            string o = $"{resolutionList[i].width}x{resolutionList[i].height}";
            options.Add(o);

            if (resolutionList[i].width == Screen.currentResolution.width && resolutionList[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        dropdownResolution.AddOptions(options);
        dropdownResolution.value = currentResolutionIndex;
        dropdownResolution.RefreshShownValue();
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        if (Screen.fullScreen)
        {
            isFullscreen = !isFullscreen;
            Screen.fullScreen = isFullscreen;
        }
        else Screen.fullScreen = true;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutionList[dropdownResolution.value];
        
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void UpdateVolume(float value)
    {
        textAudioPercent.text = $"{Mathf.RoundToInt(SliderVolume.value)}%";
    }
}
