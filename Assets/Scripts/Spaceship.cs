using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    public float speed = 30.0f;

    public GameObject theBullet;

    public Transform initialPosition;

    private void Start()
    {
        initialPosition = gameObject.transform;
    }

    private void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;


    }

    private void OnDestroy()
    {
        GameObject life = GameObject.FindGameObjectWithTag("Life");

        if(life != null)
        {
            Destroy(life);
        }
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
