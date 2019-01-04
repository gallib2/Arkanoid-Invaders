using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    public float speed = 30.0f;

    private Rigidbody2D rb;

    public Sprite explodedAlienImage;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.up * speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if(collision.tag == "Alien")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUiScore();

            collision.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            Destroy(gameObject);

            Destroy(collision.gameObject, 0.5f);
        }

        if(collision.tag == "Shield")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void IncreaseTextUiScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 10;

        textUIComp.text = score.ToString();
    } 
}
