using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static GameMaster gameMaster;
    private const int NumberOfLives = 3;
    private static int _remainingLives = NumberOfLives;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private GameObject gameEndUI;

    public static int RemainingLives
    {
        get { return _remainingLives; }
    }

	// Use this for initialization
	void Awake () {
		if(gameMaster == null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        }
	}

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _remainingLives = NumberOfLives;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void EndGame()
    {
        //gameOverUI.SetActive(true);
        gameEndUI.SetActive(true);
    }

    public static void AllAliensDead()
    {
        gameMaster.EndGame();
    }

    public static void PlayerHit()
    {
        _remainingLives--;
        if(_remainingLives <= 0)
        {
            gameMaster.GameOver();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
