using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicManager : MonoBehaviour
{
    
    public AudioSource audioSrc;
    public Slider volumeSlider;

    private float musicVolume = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("musicVolume", 1);
        audioSrc.Play();
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        audioSrc.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
