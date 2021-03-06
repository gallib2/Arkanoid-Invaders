﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public float speed = 30.0f;

    private Rigidbody2D rigidbody;

    public Sprite startImage;
    public Sprite altImage;
    public SpriteRenderer spriteRenderer;
    public const int maxBullets = 5;
    public int numberOfCurrentBulletInAir = 0;

    public float secondsBeforeSpriteChange = 0.5f;

    public GameObject alienBullet;

    //public float minFireRateTime = 10.0f;
    //public float maxFireRateTime = 20.0f;
    //public float baseFireWaitTime = 10.0f;

    public Sprite explodedShipImage;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(1, 0) * speed;

        spriteRenderer = GetComponent<SpriteRenderer>();

       // StartCoroutine(ChangeAlienSprite());

        //baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);
	}

    // turn in opposite direction
    private void Turn(int direction)
    {
        Vector2 newVelocity = rigidbody.velocity;
        newVelocity.x = speed * direction;

        rigidbody.velocity = newVelocity;
    }

    // move down after hitting wall
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 1;

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        const int moveRight = 1;
        const int moveLeft = -1;

        if(collision.gameObject.name == "LeftWall")
        {
            Turn(moveRight);
            MoveDown();
        }
        if (collision.gameObject.name == "RightWall")
        {
            Turn(moveLeft);
            MoveDown();
        }

        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.alienDies);
            Destroy(gameObject);
        }

        //if(collision.gameObject.tag == "Ball")
        //{
        //    Destroy(gameObject);
        //}
    }

    //public IEnumerator ChangeAlienSprite()
    //{
    //    while(true)
    //    {
    //        //if(spriteRenderer.sprite == startImage)
    //        //{
    //        //    spriteRenderer.sprite = altImage;
    //        //    SoundManager.Instance.playOneShot(SoundManager.Instance.alienBuzz1);
    //        //}
    //        //else
    //        //{
    //        //    spriteRenderer.sprite = startImage;
    //        //    SoundManager.Instance.playOneShot(SoundManager.Instance.alienBuzz2);
    //        //}

    //        yield return new WaitForSeconds(secondsBeforeSpriteChange);
    //    }
    //}

    private void FixedUpdate()
    {
        //if(Time.time > baseFireWaitTime && numberOfCurrentBulletInAir < maxBullets)
        //{
        //   baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

        //   Instantiate(alienBullet, transform.position, Quaternion.identity);

        //    numberOfCurrentBulletInAir++;
        //} 
        //else if(numberOfCurrentBulletInAir >= maxBullets)
        //{
        //    numberOfCurrentBulletInAir = 0;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.shipExplosion);
            collision.GetComponent<SpriteRenderer>().sprite = explodedShipImage;

            Destroy(gameObject);
            Destroy(gameObject, 0.5f);
        }
    }
}
