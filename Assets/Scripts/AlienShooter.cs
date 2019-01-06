﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienShooter : MonoBehaviour {

    public const int maxBullets = 5;
    public static int numberOfCurrentBulletInAir = 0;

    public float minFireRateTime = 10.0f;
    public float maxFireRateTime = 20.0f;
    public float baseFireWaitTime = 10.0f;

    private int numberOfCurrentAliens;
    private int numberOfAliens;

    public GameObject alienBullet;

    GameObject[] aliens;

    // Use this for initialization
    void Start () {
		if(aliens == null)
        {
            aliens = GameObject.FindGameObjectsWithTag("Alien");
        }

        numberOfAliens = aliens.Length;
        numberOfCurrentAliens = numberOfAliens;

        Debug.Log("numberOfCurrentAliens: " + numberOfCurrentAliens);

        baseFireWaitTime = 2.0f;//baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);
    }

    void OnEnable()
    {
        Alien.OnAlienDead += AlienDead;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //numberOfCurrentBulletInAir = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int randomIndex = GetRandomIndex();
        GameObject randomAlien = aliens[randomIndex];

        CheckIfEndGame();

        Shoot(randomAlien);

    }

    private void CheckIfEndGame()
    {
        if (numberOfCurrentAliens <= 0)
        {
            GameMaster.AllAliensDead();
        }
    }

    public void AlienDead()
    {
        numberOfCurrentAliens--;
    }

    private void Shoot(GameObject randomAlien)
    {
        if (randomAlien != null)
        {
            if (Time.time > baseFireWaitTime && numberOfCurrentBulletInAir < maxBullets)
            {
                baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

                Instantiate(alienBullet, randomAlien.transform.position, Quaternion.identity);

                numberOfCurrentBulletInAir++;
            }
        }
    }

    private int GetRandomIndex()
    {
        const int minIndex = 0;
        int maxIndex = aliens.Length;
        int randomIndex = Random.Range(minIndex, maxIndex - 1);

        return randomIndex;
    }
}
