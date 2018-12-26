using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    public float speed = 30.0f;

    public GameObject theBullet;

    private void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    // Update is called once per frame
    void Update () {

        //if (Input.GetMouseButtonDown(0)) // (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(theBullet, transform.position, Quaternion.identity);

        //    SoundManager.Instance.playOneShot(SoundManager.Instance.bulletFire);
        //}
	}
}
