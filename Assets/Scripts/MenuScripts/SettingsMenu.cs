using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Slider volSlider;

    public Toggle fullScreenToggle;

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    public TMP_Dropdown qualityDropdown;

    Resolution[] resolutions;

    private bool isFullScreen = false;

    private int screenInt;

    const string prefName = "optionValue";
    const string resName = "resolutionoption";

    void Awake()
    {
        screenInt = PlayerPrefs.GetInt("toggleState");

        if(screenInt == 1)
        {
            isFullScreen = true;
            fullScreenToggle.isOn = true;
        }
        else
        {
            fullScreenToggle.isOn = false;
        }

        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resolutionDropdown.value);
            PlayerPrefs.Save();
        }));

        qualityDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, qualityDropdown.value);
            PlayerPrefs.Save();
        }));
    }

    private void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        audioMixer.SetFloat("volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume"))*20);

        qualityDropdown.value = PlayerPrefs.GetInt(prefName, 0);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int index)
    {
        Resolution resolution = resolutions[index];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        audioMixer.SetFloat("volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume"))*20);
    }

    public void SetQuality (int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        if (isFullScreen == false)
        {
            PlayerPrefs.SetInt("toggleState", 0);
            Screen.fullScreen = isFullScreen;
        }
        else
        {
            isFullScreen = true;
            PlayerPrefs.SetInt("toggleState", 1);
            Screen.fullScreen = isFullScreen;
        }
    }
}
