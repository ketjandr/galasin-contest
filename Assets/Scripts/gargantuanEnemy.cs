using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gargantuanEnemy : MonoBehaviour
{
    public GameObject player;
    private float chaseSpeed = 25;
    private float enemySpeed = 2;
    public float speed;
    public float[] boundaries;
    public float randomNumber;
    public bool isMovingUp;
    playerController playerController;
    public float scaleDir;
    private bool isPowerReady = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.Find("Player").GetComponent<playerController>();

        // set boundaries (yMin, yMax)


        randomNumber = Mathf.Floor(Random.Range(1f, 3f));
        if (randomNumber == 1)
        {
            isMovingUp = true;
        }
        else if (randomNumber >= 2)
        {
            isMovingUp = false;
        }

        scaleDir = transform.localScale.x;
 



    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.active == true)
        {
            Boundaries();

            //get distance
            Vector3 posA = player.transform.position;
            Vector3 posB = transform.position;
            float dist = Vector3.Distance(posA, posB);

            if (dist < 3 && isPowerReady == true)
            {
                isPowerReady = false;
                StartCoroutine(Chase());
            }
            else
            {
                Move();
            }

            Face();
        }


    }


    IEnumerator Chase()
    {
            if (player.transform.position.x > transform.position.x)
            {

                for (int i = 0; i < 50; i++)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * chaseSpeed);
                    yield return new WaitForSeconds(0.02f);
                }
                for (int i = 0; i < 50; i++)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * -chaseSpeed);
                    yield return new WaitForSeconds(0.02f);
                }
            }
            else if (player.transform.position.x < transform.position.x)
            {
                for (int i = 0; i < 50; i++)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * -chaseSpeed);
                    yield return new WaitForSeconds(0.02f);
                }
                for (int i = 0; i < 50; i++)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * chaseSpeed);
                    yield return new WaitForSeconds(0.02f);
                }
            }
            yield return new WaitForSeconds(2f);
            isPowerReady = true;

    }


    void Move()
    {

        if (isMovingUp == true)
        {
            speed = enemySpeed;
        }
        else if (isMovingUp == false)
        {
            speed = -enemySpeed;
        }

        if (isMovingUp == false && transform.position.y <= boundaries[0])
        {
            isMovingUp = true;
        }
        else if (isMovingUp == true && transform.position.y >= boundaries[1])
        {
            isMovingUp = false;
        }

        transform.Translate(Vector3.up * Time.deltaTime * speed);



    }

    void Boundaries()
    {

        if (transform.position.y < boundaries[0])
        {
            transform.position = new Vector3(transform.position.x, boundaries[0], transform.position.z);
        }
        if (transform.position.y > boundaries[1])
        {
            transform.position = new Vector3(transform.position.x, boundaries[1], transform.position.z);
        }
    }

    void Face()
    {
        if (playerController.lap == 1)
        {
            transform.localScale = new Vector3(scaleDir, transform.localScale.y, transform.localScale.z);
        }
        else if (playerController.lap == 2)
        {
            transform.localScale = new Vector3(-scaleDir, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerController.life > 0)
        {
            playerController.life = 0;
        }



    }
}
