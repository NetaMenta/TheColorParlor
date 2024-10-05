using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    [SerializeField] GameManager gamemanager;
    [SerializeField] GameObject endingCanvas;
    int currentLevel;
    public bool CheckIfGameEnded()
    {
        if(gamemanager.accuracyResults.Count >= gamemanager.levelLength)
        {
            return true;
        }
        return false;
    }

    public void showEndCanvas()
    {
        if(CheckIfGameEnded())
        endingCanvas.SetActive(true);
    }

    public void HideEndCanvas()
    {
        endingCanvas.SetActive(false);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        gamemanager.RestartGame();
        HideEndCanvas();
    }
}
