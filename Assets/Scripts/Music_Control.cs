using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music_Control : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider BGM_slider, Jump_Effect_Slider;
    public AudioSource BG_Music, Jump_Effect,magic_Effct;
    public GameObject Settings;
    public AudioClip jump;
    public GameObject Instructions;
    int Mute_clicktimes = 0;
    public bool change = false;

    public void Change_BGM_volume()
    {
        BG_Music.volume = BGM_slider.value;

    }

    public void Change_Jump_Effect_volume()
    {
        Jump_Effect.volume = Jump_Effect_Slider.value;
        magic_Effct.volume = Jump_Effect_Slider.value;
    }

    /*public void MuteClick()
    {
        Mute_clicktimes++;
        if (Mute_clicktimes % 2 == 1)
        {
            BG_Music.volume = 0;
            BGM_slider.value = 0;
        }
        else
        {
            BG_Music.volume = 0.5f;
            BGM_slider.value = 0.5f;
        }
    }*/

    public void Setting_Click()
    {
        Settings.SetActive(true);
    }

    public void SettingClose_Click()
    {
        Settings.SetActive(false);
    }

    public void BackToOpen_Click()
    {
        SceneManager.LoadScene(0);
    }
    public void Instructions_Click()
    {
        Instructions.SetActive(true);
    }
    public void InstructionsClose_Click()
    {
        Instructions.SetActive(false);
    }
}
