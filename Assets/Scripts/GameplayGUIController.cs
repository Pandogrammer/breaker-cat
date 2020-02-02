using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayGUIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject restartPanel; 
    [SerializeField] private Button restartButton; 
    [SerializeField] private Button goToMenuButton;
    private int objectCount;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartScene);
        goToMenuButton.onClick.AddListener(GoToMenu);
    }

    private void RestartScene()
    {
         Application.LoadLevel(Application.loadedLevel);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void SetScore(int score)
    {
        scoreText.text = $"Repaired: {score}/{objectCount}";
    }

    public void Setup(int objectCount, int time)
    {
        this.objectCount = objectCount;
        SetTimer(time);
        SetScore(0);
    }

    public void ShowWin()
    {
        PresentEndGame("YOU WIN!");
    }

    public void ShowLose()
    {
        PresentEndGame("YOU LOSE :c");
    }

    private void PresentEndGame(string endMessage)
    {
        timeText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        finishText.text = endMessage;
        finishText.gameObject.SetActive(true);
        restartPanel.SetActive(true);
    }

    public void SetTimer(int time)
    {
        timeText.text = $"Time: {time.ToString()}";
    }
}
