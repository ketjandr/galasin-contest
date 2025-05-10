using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private float speed = 3;
    public Animator animator;
    public float[] boundaries;
    public float[] mapBoundaries;
    public GameObject player;
    public int life = 1;
    public bool active = false;
    public bool canTriggerHappen = true;
    public int lap = 1;
    public float timeValue = 0;
    public string bgMusic;
    lapIndicators lapIndicators;
    soundManager soundManager;
    musicManager musicManager;
   
    // Start is called before the first frame update
    void Start()
    {
        //active = true;
        lapIndicators = GameObject.Find("Start and Finish Indicators").GetComponent<lapIndicators>();
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
        musicManager = GameObject.Find("MusicManager").GetComponent<musicManager>();
        life = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            Move();
            LifeCheck();
            LapCheck();
            
        }
        
      
    }

    void Move()
    {

        
        //vertical movemnt (y-axis)
        verticalInput = Input.GetAxis("Vertical");


        if (verticalInput < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
           

        }
        else if (verticalInput > 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
           


        }
        else
        {
           
        }

        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 characterScale = transform.localScale;


        //horizontal movement (x-axis)

        if (horizontalInput < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            characterScale.x = -2.55f;
           



        }
        else if (horizontalInput > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            characterScale.x = 2.55f;
           


        }

        animator.SetFloat("Movement", Mathf.Abs(horizontalInput));

        if (verticalInput > 0)
        {
            animator.SetFloat("Movement", Mathf.Abs(verticalInput));
            
        } else if (verticalInput < 0)
        {
            animator.SetFloat("Movement", Mathf.Abs(verticalInput));
            
        }
        

        transform.localScale = characterScale;

        //set boundaries (xMax, xMin, yMin, yMax)



        if (player.transform.position.x > boundaries[0])
        {
            player.transform.position = new Vector3(boundaries[0], transform.position.y, transform.position.z);
        }
        if (player.transform.position.x < boundaries[1])
        {
            player.transform.position = new Vector3(boundaries[1], transform.position.y, transform.position.z);
        }
        if (player.transform.position.y < boundaries[2])
        {
            player.transform.position = new Vector3(transform.position.x, boundaries[2], transform.position.z);
        } 
        if (player.transform.position.y > boundaries[3])
        {
            player.transform.position = new Vector3(transform.position.x, boundaries[3], transform.position.z);
        }


        if (horizontalInput != 0 || verticalInput != 0)
        {
            int soundInput = Random.Range(0, 2);
            if (!soundManager.audioSrc.isPlaying)
            {
                if (soundInput == 0)
                {
                    soundManager.PlaySound("grass-walk01");
                }
                else if (soundInput == 1)
                {
                    soundManager.PlaySound("grass-walk02");
                }
                

            }
        }





    }

    void LifeCheck()
    {
        if (life <= 0 && canTriggerHappen == true)
        {
            Debug.Log("You Lose");
            canTriggerHappen = false;
            active = false;
            animator.SetFloat("Movement", 0);
            controllerUI.instance.LoseNotif();
            soundManager.PlaySound("Lose Notif");
        }
    }

    void LapCheck()
    {
        if (lap == 1)
        {
            if (transform.position.x >= mapBoundaries[1])
            {
                lap = 2;
            }
        } else if (lap == 2)
        {
            if (transform.position.x <= mapBoundaries[0])
            {
                Win();
            }
        }
    }

    void Win()
    {
        if (canTriggerHappen == true)
        {
            Debug.Log("Win");
            canTriggerHappen = false;
            active = false;
            animator.SetFloat("Movement", 0);
            controllerUI.instance.WinNotif();
            soundManager.PlaySound("Crowd Sounds");
        }
        
    }


    IEnumerator TimeTick()
    {
        
            if (active == true)
            {
                timeValue += 1;
                yield return new WaitForSeconds(1f);
            }
        
    }

    void TimeStart()
    {
        StartCoroutine("TimeTick");
    }

}
