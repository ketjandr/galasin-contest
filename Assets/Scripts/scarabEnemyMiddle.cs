using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarabEnemyMiddle : MonoBehaviour
{
    public GameObject player;
    private float chaseSpeed = 4;
    private float enemySpeed = 4;
    public float speed;
    public float[] boundaries;
    public float randomNumber;
    public bool isMovingUp;
    public float scaleDir;
    playerController playerController;

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

        scaleDir = transform.localScale.y;



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

            if (Mathf.Abs(player.transform.position.y - transform.position.y) < 2)
            {
                Chase();
            }
            else
            {
                Move();
            }

            Face();

            Face();
        }


    }


    void Chase()
    {


        if (player.transform.position.x > transform.position.x)
        {
            transform.Translate(Vector3.right * Time.deltaTime * chaseSpeed);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            transform.Translate(Vector3.right * Time.deltaTime * -chaseSpeed);
        }


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

        if (isMovingUp == false && transform.position.x <= boundaries[0])
        {
            isMovingUp = true;
        }
        else if (isMovingUp == true && transform.position.x >= boundaries[1])
        {
            isMovingUp = false;
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed);



    }

    void Boundaries()
    {


        if (transform.position.x < boundaries[0])
        {
            transform.position = new Vector3(boundaries[0], transform.position.y, transform.position.z);
        }
        if (transform.position.x > boundaries[1])
        {
            transform.position = new Vector3(boundaries[1], transform.position.y, transform.position.z);
        }
    }

    void Face()
    {
        if (player.transform.position.y >= transform.position.y)
        {

            transform.localScale = new Vector3(transform.localScale.x, scaleDir, transform.localScale.z);
        }
        else if (player.transform.position.y <= transform.position.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, -scaleDir, transform.localScale.z);
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
