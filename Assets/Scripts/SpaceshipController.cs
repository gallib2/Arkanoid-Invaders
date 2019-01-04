using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

    public Spaceship spaceship;

    private void Start()
    {
       // spaceship = GetComponent<Spaceship>();
    }

    private void Update()
    {
        Debug.Log("spaceship: ");
        Debug.Log(spaceship.gameObject);
        if(spaceship == null)
        {
            OnSpaceshipDestroy();
        }
    }

    private void OnSpaceshipDestroy()
    {
        Debug.Log("here in spaceship conrteoller");
        Instantiate(spaceship, spaceship.initialPosition);
    }
}
