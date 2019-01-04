using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {
    public delegate void SpaceShipDestroyAction();
    public static event SpaceShipDestroyAction OnSpaceShipDestroy;
    public Sprite spaceshipImag;

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


    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = spaceshipImag;
        print(Time.time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AlienBullet")
        {
            SpaceshipHit();
            StartCoroutine(Example());
        }
    }

    private void SpaceshipHit()
    {
        GameObject[] lifes = GameObject.FindGameObjectsWithTag("Life");
        Stack lifesStack = new Stack(lifes);

        if (lifesStack.Count > 0)
        {
            //Destroy(life);
            ((GameObject)lifesStack.Pop()).SetActive(false);
            // Debug.Log("before calling on destroy");
            //if (OnSpaceShipDestroy != null)
            //{
            //    OnSpaceShipDestroy();
            //}
        }
    }

    //private void OnDisable()
    //{
    //  //  Debug.Log("before get lifes");
    //    GameObject life = GameObject.FindGameObjectWithTag("Life");
    //    //Debug.Log("before if");
    //    if (life != null)
    //    {
    //        //Destroy(life);
    //        life.SetActive(false);
    //       // Debug.Log("before calling on destroy");
    //        if (OnSpaceShipDestroy != null)
    //        {
    //            OnSpaceShipDestroy();
    //        }
    //    }
    //}

    //private void OnDestroy()
    //{
    //    //Debug.Log("before get lifes in on destroy");
    //    GameObject life = GameObject.FindGameObjectWithTag("Life");
    //    if (life != null)
    //    {
    //        //Destroy(life);
    //        life.SetActive(false);
            
    //        if (OnSpaceShipDestroy != null)
    //        {
    //            OnSpaceShipDestroy();
    //        }
    //    }
    //}
}
