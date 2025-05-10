using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapIndicators : MonoBehaviour
{
    public float[] mapBoundaries;
    public bool isTimerActive;
    playerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<playerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.active == false && isTimerActive == true)
        {
            TimerController.instance.EndTimer();
            isTimerActive = false;
        } else if (playerController.active == true && isTimerActive == false)
        {
            TimerController.instance.BeginTimer();
            isTimerActive = true;
        }
    }
}
