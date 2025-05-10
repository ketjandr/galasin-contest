using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerUI : MonoBehaviour
{
    public static controllerUI instance;
    public GameObject background, woodBlock, pauseText, winningText, losingText,
        currentTimeText, bestTimeText, playButton, homeButton, restartButton,
        settingsText, sliderSound, sliderMusic, soundText, musicText, settingsPlayButton,
        levelIndicator;
    playerController playerController;
    public Button pause;
    public Button settings;
    public Text currentScore;
    public Text bestScore;
    public float timeScoreBest;
    public string timeScoreBestStr;
    public int levelValue;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {   /*
        //Reset High Scores
        PlayerPrefs.SetFloat("highscore", 0);
        PlayerPrefs.SetString("highscoreStr", "None");

        PlayerPrefs.SetFloat("highscore2", 0);
        PlayerPrefs.SetString("highscoreStr2", "None");

        PlayerPrefs.SetFloat("highscore3", 0);
        PlayerPrefs.SetString("highscoreStr3", "None");

        PlayerPrefs.SetFloat("highscore4", 0);
        PlayerPrefs.SetString("highscoreStr4", "None");

        PlayerPrefs.SetFloat("highscore5", 0);
        PlayerPrefs.SetString("highscoreStr5", "None");

        PlayerPrefs.SetFloat("highscore6", 0);
        PlayerPrefs.SetString("highscoreStr6", "None");

        PlayerPrefs.SetFloat("highscore7", 0);
        PlayerPrefs.SetString("highscoreStr7", "None");

        PlayerPrefs.SetFloat("highscore8", 0);
        PlayerPrefs.SetString("highscoreStr8", "None");
        */

        playerController = GameObject.Find("Player").GetComponent<playerController>();
        pause = GameObject.Find("pause-button").GetComponent<Button>();
        settings = GameObject.Find("settings-button").GetComponent<Button>();

        switch (levelValue)
        {
            case 1:
                timeScoreBest = PlayerPrefs.GetFloat("highscore");
                timeScoreBestStr = PlayerPrefs.GetString("highscoreStr");
                break;
            case 2:
                timeScoreBest = PlayerPrefs.GetFloat("highscore2");
                timeScoreBestStr = PlayerPrefs.GetString("highscoreStr2");
                break;
            case 3:
                timeScoreBest = PlayerPrefs.GetFloat("highscore3");
                timeScoreBestStr = PlayerPrefs.GetString("highscoreStr3");
                break;
            case 4:
                timeScoreBest = PlayerPrefs.GetFloat("highscore4");
                timeScoreBestStr = PlayerPrefs.GetString("highscoreStr4");
                break;
            case 5:
                timeScoreBest = PlayerPrefs.GetFloat("highscore5");
                timeScoreBestStr = PlayerPrefs.GetString("highscoreStr5");
                break;
            case 6:
                timeScoreBest = PlayerPrefs.GetFloat("highscore6");
                timeScoreBestStr = PlayerPrefs.GetString("highscoreStr6");
                break;
            case 7:
                timeScoreBest = PlayerPrefs.GetFloat("highscore7");
                timeScoreBestStr = PlayerPrefs.GetString("highscoreStr7");
                break;
            case 8:
                timeScoreBest = PlayerPrefs.GetFloat("highscore8");
                timeScoreBestStr = PlayerPrefs.GetString("highscoreStr8");
                break;
        }
 

        

        if (timeScoreBest == 0)
        {
            timeScoreBest = 999999;
        }

    }

    private void Update()
    {
        if (playerController.active == false)
        {
            pause.interactable = false;
            settings.interactable = false;
        }
        else if (playerController.active == true)
        {
            pause.interactable = true;
            settings.interactable = true;
        }



    }

    public void Pause()
    {
        playerController.active = false;
        background.SetActive(true);
        woodBlock.SetActive(true);
        pauseText.SetActive(true);
        playButton.SetActive(true);
        homeButton.SetActive(true);
        



    }

    public void UnPause()
    {
        playerController.active = true;
        background.SetActive(false);
        woodBlock.SetActive(false);
        pauseText.SetActive(false);
        playButton.SetActive(false);
        homeButton.SetActive(false);
    }

    public void WinNotif()
    {
        playerController.active = false;
        background.SetActive(true);
        woodBlock.SetActive(true);
        winningText.SetActive(true);
        currentTimeText.SetActive(true);
        bestTimeText.SetActive(true);
        restartButton.SetActive(true);
        homeButton.SetActive(true);
        levelIndicator.SetActive(true);

        currentScore.text = "Current Time: " + TimerController.instance.timeObtainedStr;

        if (TimerController.instance.timeScore < timeScoreBest)
        {
            bestScore.text = "Best Time: " + TimerController.instance.timeObtainedStr;
            timeScoreBest = TimerController.instance.timeScore;
            timeScoreBestStr = TimerController.instance.timeObtainedStr;
            

            switch (levelValue)
            {
                case 1:
                    PlayerPrefs.SetFloat("highscore", timeScoreBest);
                    PlayerPrefs.SetString("highscoreStr", timeScoreBestStr);
                    break;
                case 2:
                    PlayerPrefs.SetFloat("highscore2", timeScoreBest);
                    PlayerPrefs.SetString("highscoreStr2", timeScoreBestStr);
                    break;
                case 3:
                    PlayerPrefs.SetFloat("highscore3", timeScoreBest);
                    PlayerPrefs.SetString("highscoreStr3", timeScoreBestStr);
                    break;
                case 4:
                    PlayerPrefs.SetFloat("highscore4", timeScoreBest);
                    PlayerPrefs.SetString("highscoreStr4", timeScoreBestStr);
                    break;
                case 5:
                    PlayerPrefs.SetFloat("highscore5", timeScoreBest);
                    PlayerPrefs.SetString("highscoreStr5", timeScoreBestStr);
                    break;
                case 6:
                    PlayerPrefs.SetFloat("highscore6", timeScoreBest);
                    PlayerPrefs.SetString("highscoreStr6", timeScoreBestStr);
                    break;
                case 7:
                    PlayerPrefs.SetFloat("highscore7", timeScoreBest);
                    PlayerPrefs.SetString("highscoreStr7", timeScoreBestStr);
                    break;
                case 8:
                    PlayerPrefs.SetFloat("highscore8", timeScoreBest);
                    PlayerPrefs.SetString("highscoreStr8", timeScoreBestStr);
                    break;
            }

        } else if (TimerController.instance.timeScore >= timeScoreBest)
        {
            bestScore.text = "Best Time: " + timeScoreBestStr;
            
        }
    }

    public void LoseNotif()
    {
        playerController.active = false;
        background.SetActive(true);
        woodBlock.SetActive(true);
        losingText.SetActive(true);
        bestTimeText.SetActive(true);
        restartButton.SetActive(true);
        homeButton.SetActive(true);
        levelIndicator.SetActive(true);

        bestScore.text = "Best Time: " + timeScoreBestStr;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_" + levelValue);
    }

    public void Settings()
    {
        playerController.active = false;
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
        playerController.active = true;
        background.SetActive(false);
        woodBlock.SetActive(false);
        settingsText.SetActive(false);
        sliderSound.SetActive(false);
        sliderMusic.SetActive(false);
        soundText.SetActive(false);
        musicText.SetActive(false);
        settingsPlayButton.SetActive(false);
    }

    public void ReturnToHome()
    {
        sceneManager.instance.OpenScene(0);
    }
}
