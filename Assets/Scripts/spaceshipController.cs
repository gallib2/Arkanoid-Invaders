using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipController : MonoBehaviour {

    public Spaceship spaceship;
    public Ball ball;

    private void OnEnable()
    {
        Spaceship.OnSpaceShipDestroy += OnSpaceshipDestroy;
    }

    //private void OnDisable()
    //{
    //    Spaceship.OnSpaceShipDestroy += OnSpaceshipDestroy;
    //}

    private void Start()
    {
    }


    private void Update()
    {
        //Debug.Log(spaceship.gameObject.activeSelf);
        //if(!spaceship.isActiveAndEnabled)
        //{
        //    Debug.Log("besdfj;sdf;s;1");
        //    spaceship.enabled = true;
        //    spaceship.gameObject.SetActive(true);
        //}
    }

    private void OnSpaceshipDestroy()
    {
        //Instantiate(spaceship);
        //Debug.Log("before set acitve spaceship:");
        //spaceship.enabled = true;

        //spaceship.gameObject.SetActive(true);
        //Debug.Log(spaceship.isActiveAndEnabled);
        //Debug.Log("sdfjklsdfjkl");
        //spaceship.gameObject.
        //Instantiate(ball);
        //Debug.Log("before Ball:");

        //ball = GetComponent<Ball>();
        //Debug.Log(ball);
        //Debug.Log(ball.paddleTransorm);
        // Debug.Log(GameObject.FindGameObjectWithTag("BallPosition").transform);

        // ball.paddleTransorm = GameObject.FindGameObjectWithTag("BallPosition").transform;

        //BallPosition p = spaceship.GetComponentInChildren<BallPosition>();
        //if(ball != null)
        //{
        //    ball.paddleTransorm;
        //}
        //Instantiate(ball);
    }
}
