using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public SceneFade sceneFade;

    private void Start()
    {
        gameIsOver = false;
    }
    private void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        //fonction de test
        if (Input.GetKeyDown("x"))
        {
            EndGame();
        }

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        Debug.Log("Game over");
        gameOverUI.SetActive(true);
    }

    public void WinLevel(){
        Debug.Log("Win");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFade.FadeTo(nextLevel);

    }
}
