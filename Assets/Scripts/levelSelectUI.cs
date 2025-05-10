using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelectUI : MonoBehaviour
{
    public static levelSelectUI instance;
    public GameObject background, woodBlock, settingsText, sliderSound, sliderMusic,
        soundText, musicText, settingsPlayButton;
    public int levelValue;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    private void Update()
    {



    }


    public void Settings()
    {
        background.SetActive(true);
        woodBlock.SetActive(true);
        settingsText.SetActive(true);
        sliderSound.SetActive(true);
        sliderMusic.SetActive(true);
        soundText.SetActive(true);
        musicText.SetActive(true);
        settingsPlayButton.SetActive(true);
    }

    public void SettingsUnPause()
    {
        background.SetActive(false);
        woodBlock.SetActive(false);
        settingsText.SetActive(false);
        sliderSound.SetActive(false);
        sliderMusic.SetActive(false);
        soundText.SetActive(false);
        musicText.SetActive(false);
        settingsPlayButton.SetActive(false);
    }

    public void GoToLevel(int levelValue)
    {
        sceneManager.instance.OpenScene(levelValue + 1);
    }


    public void ReturnToHome()
    {
        sceneManager.instance.OpenScene(0);
    }



}


