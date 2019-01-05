using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {
    public delegate void SpaceShipDestroyAction();
    public static event SpaceShipDestroyAction OnSpaceShipHit;
    public Sprite spaceshipImag;
    public Vector3 initialTransform;

    public float speed = 30.0f;

    public GameObject theBullet;

    private void Start()
    {
        initialTransform = new Vector3();
        initialTransform = gameObject.transform.position;
    }

    private void InitTransform()
    {
        gameObject.transform.position = initialTransform;
    }

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


    IEnumerator SetSpaceShipImage()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = spaceshipImag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AlienBullet")
        {
            SpaceshipHit();
            StartCoroutine(SetSpaceShipImage());
            InitTransform();
            if (OnSpaceShipHit != null)
            {
                OnSpaceShipHit();
            }
        }
    }

    private void SpaceshipHit()
    {
        //GameObject[] lifes = GameObject.FindGameObjectsWithTag("Life");
        //Stack lifesStack = new Stack(lifes);

        //if (lifesStack.Count > 0)
        //{
        //    ((GameObject)lifesStack.Pop()).SetActive(false);
        //}

        GameMaster.PlayerHit();
    }

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
