using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (musicSlider != null && soundSlider != null)
        {
            musicSlider.value = ProfileManager.musicVol;
            soundSlider.value = ProfileManager.soundVol;
        }
    }

    public void goMenu()
    {
        ProfileManager.musicVol = musicSlider.value;
        ProfileManager.soundVol = soundSlider.value;
        ProfileManager.updateVolume(musicSlider.value, soundSlider.value);
        SceneManager.LoadScene("MainMenu");

    }

    public void goControls()
    {
        ProfileManager.musicVol = musicSlider.value;
        ProfileManager.soundVol = soundSlider.value;
        ProfileManager.updateVolume(musicSlider.value, soundSlider.value);
        SceneManager.LoadScene("Controls");
    }

    public void goSettings()
    {
        SceneManager.LoadScene("Options");
    }


}
