using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour {

    public AlienShooter alienShooter;

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        Instantiate(alienShooter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
