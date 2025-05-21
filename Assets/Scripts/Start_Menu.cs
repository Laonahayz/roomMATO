using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Start_Menu : MonoBehaviour
{
    public GameObject Setting;
    public Slider BGM_slider, Jump_Effect_Slider;
    public AudioSource BG_Music, Jump_Effect;
    
    //Scene Open = SceneManager.GetActiveScene();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Setting.activeInHierarchy == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }*/
    }

    public void Change_BGM_volume()
    {
        BG_Music.volume = BGM_slider.value;

    }

    public void Change_Jump_Effect_volume()
    {
        Jump_Effect.volume = Jump_Effect_Slider.value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        
    }

    public void Setting_Open()
    {
        Setting.SetActive(true);
        
        
    }

    public void Setting_Close()
    {
        Setting.SetActive(false);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
