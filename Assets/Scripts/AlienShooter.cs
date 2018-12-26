using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShooter : MonoBehaviour {

    public const int maxBullets = 5;
    public int numberOfCurrentBulletInAir = 0;

    public float minFireRateTime = 10.0f;
    public float maxFireRateTime = 20.0f;
    public float baseFireWaitTime = 10.0f;

    public GameObject alienBullet;

    GameObject[] aliens;
    

	// Use this for initialization
	void Start () {
		if(aliens == null)
        {
            aliens = GameObject.FindGameObjectsWithTag("Alien");
        }

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);
    }
	
	// Update is called once per frame
	void Update () {


        if (Time.time > baseFireWaitTime/* && numberOfCurrentBulletInAir < maxBullets*/)
        {
            const int minIndex = 0;
            int maxIndex = aliens.Length;
            int randomIndex = Random.Range(minIndex, maxIndex - 1);


            GameObject randomAlien = aliens[randomIndex];

            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

            if(randomAlien != null)
            {
                Instantiate(alienBullet, randomAlien.transform.position, Quaternion.identity);

                numberOfCurrentBulletInAir++;
            }
        }
    }
}
