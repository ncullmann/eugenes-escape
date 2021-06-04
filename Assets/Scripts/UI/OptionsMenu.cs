using UnityEngine;
using UnityEngine.UI;

/**
 * Nicholas Cullmann - 5/2021
 * OptionsMenu - Allows player to change graphics, sound, mouse sensitivity, and set fullscreen.
 */

public class OptionsMenu : MonoBehaviour
{
    public Dropdown graphicsSettings;
    public NewCameraMovement cam;
    public Toggle fullscreenToggle;

    void Start()
    {
        graphicsSettings.onValueChanged.AddListener(delegate
        {
            GraphicsSettingChanged(graphicsSettings);
        });

        QualitySettings.SetQualityLevel(3, true);
        graphicsSettings.value = 3;
        AudioListener.volume = 1.0f;
        cam.SetSensitivity(0.1f);
    }


    public void AdjustVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void AdjustSensitivity(float sens)
    {
        cam.SetSensitivity(sens);
    }

    public void GraphicsSettingChanged(Dropdown dd)
    {
        QualitySettings.SetQualityLevel(dd.value, true);
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
