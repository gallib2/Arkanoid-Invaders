using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour {

    private Rigidbody2D rb;

    public float speed = 30.0f;

    public Sprite explodedSpaceShipImage;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.down * speed;
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.shipExplosion);

            collision.GetComponent<SpriteRenderer>().sprite = explodedSpaceShipImage;

            Destroy(gameObject);
            //collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject, 0.5f);
        }

        if (collision.tag == "Shield")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
