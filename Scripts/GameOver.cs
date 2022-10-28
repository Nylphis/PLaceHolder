using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public SceneFade sceneFade;
    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        sceneFade.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFade.FadeTo(menuSceneName);
    }
}
