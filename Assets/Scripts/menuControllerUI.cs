using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuControllerUI : MonoBehaviour
{
    public static menuControllerUI instance;
    public GameObject background, woodBlock, woodBlockLong, settingsText, sliderSound, sliderMusic,
        soundText, musicText, settingsPlayButton, exitButton, backButton, nextButton, prevButton;
    public GameObject controlsPack, aboutPack, almanacPack, slide1, slide2, slide3, slide4;
    public int gallerySlide;


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
        exitButton.SetActive(true);
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
        exitButton.SetActive(false);
    }

    public void Controls()
    {
        background.SetActive(true);
        woodBlockLong.SetActive(true);
        backButton.SetActive(true);
        controlsPack.SetActive(true);
    }

    public void About()
    {
        background.SetActive(true);
        woodBlockLong.SetActive(true);
        backButton.SetActive(true);
        aboutPack.SetActive(true);
    }

    public void Almanac()
    {
        background.SetActive(true);
        woodBlockLong.SetActive(true);
        backButton.SetActive(true);
        almanacPack.SetActive(true);
        gallerySlide = 1;
        Slide(gallerySlide);
    }

    public void Slide(int slideNo)
    {
        switch (slideNo)
        {
            case 1:
                CloseSlides();
                slide1.SetActive(true);
                break;
            case 2:
                CloseSlides();
                slide2.SetActive(true);
                break;
            case 3:
                CloseSlides();
                slide3.SetActive(true);
                break;
            case 4:
                CloseSlides();
                slide4.SetActive(true);
                break;

        }
    }

    public void CloseSlides()
    {
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(false);
    }

    public void nextSlide()
    {
        gallerySlide += 1;
        if (gallerySlide > 4)
        {
            gallerySlide = 1;
        }
        Slide(gallerySlide);

    }

    public void prevSlide()
    {
        gallerySlide -= 1;
        if (gallerySlide < 1)
        {
            gallerySlide = 4;
        }
        Slide(gallerySlide);

    }

    public void BackButtonActivate()
    {
        background.SetActive(false);
        woodBlockLong.SetActive(false);
        backButton.SetActive(false);
        controlsPack.SetActive(false);
        aboutPack.SetActive(false);
        almanacPack.SetActive(false);
        CloseSlides();
    }

    public void ReturnToHome()
    {
        sceneManager.instance.OpenScene(0);
    }

    public void Play()
    {
        sceneManager.instance.OpenScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
