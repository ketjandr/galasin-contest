using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    public static AudioClip grassWalk, grassWalk2, grassWalk3, grassWalk4, crowdCheer, loseNotif;
    public static AudioSource audioSrc;
    private float musicVolume = 1f;
    public Slider soundSlider;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("soundVolume", 1);
        grassWalk = Resources.Load<AudioClip>("grass-walk01");
        grassWalk2 = Resources.Load<AudioClip>("grass-walk02");
        grassWalk3 = Resources.Load<AudioClip>("grass-walk03");
        grassWalk4 = Resources.Load<AudioClip>("grass-walk04");
        grassWalk4 = Resources.Load<AudioClip>("grass-walk04");
        crowdCheer = Resources.Load<AudioClip>("Crowd Sounds");
        loseNotif = Resources.Load<AudioClip>("Lose Notif");

        audioSrc = GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("soundVolume");
        audioSrc.volume = musicVolume;
        soundSlider.value = musicVolume;

    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
        PlayerPrefs.SetFloat("soundVolume", musicVolume);
    }
    
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "grass-walk01":
                audioSrc.PlayOneShot(grassWalk);
                break;
            case "grass-walk02":
                audioSrc.PlayOneShot(grassWalk2);
                break;
            case "grass-walk03":
                audioSrc.PlayOneShot(grassWalk3);
                break;
            case "grass-walk04":
                audioSrc.PlayOneShot(grassWalk4);
                break;
            case "Crowd Sounds":
                audioSrc.PlayOneShot(crowdCheer);
                break;
            case "Lose Notif":
                audioSrc.PlayOneShot(loseNotif);
                break;
        }
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
