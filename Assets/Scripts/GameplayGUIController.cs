using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayGUIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject finishFeedback; 
    [SerializeField] private Button restartButton; 
    [SerializeField] private Button goToMenuButton;
    [SerializeField] private RawImage goodBoy;
    [SerializeField] private RawImage badBoy;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject targetScore;
    
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
        scoreText.text = $"{score}/{objectCount}";
    }

    public void Setup(int objectCount, int time)
    {
        this.objectCount = objectCount;
        SetTimer(time);
        SetScore(0);
    }

    public void ShowWin()
    {
        goodBoy.gameObject.SetActive(true);
        PresentEndGame();
    }

    public void ShowLose()
    {
        badBoy.gameObject.SetActive(true);
        PresentEndGame();
    }

    private void PresentEndGame()
    {
        timer.gameObject.SetActive(false);
        targetScore.gameObject.SetActive(false);
        finishFeedback.gameObject.SetActive(true);
        goToMenuButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void SetTimer(int time)
    {
        timeText.text = $"{time.ToString()}";
    }
}
