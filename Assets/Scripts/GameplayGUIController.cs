using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameplayGUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField] private TextMeshProUGUI timeText;
    private int objectCount;

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
        timeText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        finishText.text = "YOU WIN!";
        finishText.gameObject.SetActive(true);
    }

    public void ShowLose()
    {
        timeText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        finishText.text = "YOU LOSE :c";
        finishText.gameObject.SetActive(true);
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
