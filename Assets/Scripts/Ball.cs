using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    //public delegate void AlienDestroyAction();
    //public static event AlienDestroyAction OnAlienDead;

    Rigidbody2D rb;
    public float thrust = 500.0f;
    public bool inPlay;
    public Transform paddleTransorm;
    public Sprite explodedAlienImage;


    void Start () {

        rb = GetComponent<Rigidbody2D>();
	}

    private void OnEnable()
    {
        Spaceship.OnSpaceShipHit += InitBallPosition;
    }

    private void OnDisable()
    {
        Spaceship.OnSpaceShipHit -= InitBallPosition;
    }

    private void InitBallPosition()
    {
        //rb.velocity = Vector2.zero;
        inPlay = false;
    }

    // Update is called once per frame
    void Update () {
        if(!inPlay && paddleTransorm == null)
        {
          //  Destroy(gameObject);
        }
        else if (!inPlay)
        {
            transform.position = paddleTransorm.position;
        }

        if (!inPlay && Input.GetKeyDown(KeyCode.Space))
        {
            inPlay = true;
            rb.AddForce(Vector2.up * thrust);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BottomWall"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;


        }

        


        //if (other.tag == "Shield")
        //{
        //    Destroy(other.gameObject);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUiScore();

            collision.gameObject.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            //Destroy(gameObject);
            //AlienShooter.AlienDead();
            //if (OnAlienDead != null)
            //{
            //    OnAlienDead();
            //}

            Destroy(collision.gameObject, 0.5f);
        }
    }

    private void IncreaseTextUiScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 10;

        textUIComp.text = score.ToString();
    }
}
