using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMain : MonoBehaviour
{
    private Camera cam;
    private float targetZoom;
    private float zoomValue;
    public GameObject player;
    public Vector3 offSet = new Vector3(6, 0, -1);
    playerController playerController;
    public bool isTrigger = false;
    public bool camFinished = false;
    public float index = 6;
    public float initialValue;
    public float speed = -2;
    public float moveSpeed;
    public float currentXpos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
        zoomValue = cam.orthographicSize;
        playerController = GameObject.Find("Player").GetComponent<playerController>();
        StartCameraActive();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.active == true)
        {
            if (playerController.lap == 2 && isTrigger == false)
            {
                StartPanning();
                isTrigger = true;
            }
            

        }

        if (camFinished == true)
        {
            transform.position = player.transform.position + offSet;

        }

        


    }

    IEnumerator PanCamera()
    {
        playerController.active = false;
        for (int i = 0; i < 50; i++)
        {
            index = index - 0.24f;
            offSet = new Vector3(index, 0, -1);
            yield return new WaitForSeconds(0.02f);
        }
        offSet = new Vector3(-6, 0, -1);
        playerController.active = true;
    }

    IEnumerator StartCamera()
    {
        for (int i = 0; i < 80; i++)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            yield return new WaitForSeconds(0.02f);
        }

        currentXpos = transform.position.x;

        for (int i = 0; i < 50; i++)
        {
            initialValue = (zoomValue - 5f) / 50f;
            cam.orthographicSize = targetZoom - initialValue;
            targetZoom = targetZoom - initialValue;

            moveSpeed = (currentXpos - player.transform.position.x - 6) / 50;
            transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
        playerController.active = true;
        camFinished = true;
    }

    void StartPanning()
    {
        StartCoroutine("PanCamera");
    }

    void StartCameraActive()
    {
        StartCoroutine("StartCamera");
    }
}
