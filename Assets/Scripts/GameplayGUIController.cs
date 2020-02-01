using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayGUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject restartPanel; 
    [SerializeField] private Button restartButton;
    private int objectCount;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartScene);
    }

    private void RestartScene()
    {
         Application.LoadLevel(Application.loadedLevel);
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

    public void SetEndingTimer(float time)
    {
        timeText.color = Color.red;
        timeText.fontStyle = FontStyles.Bold;
        timeText.text = $"TIME: {time.ToString()}";
    }
}
