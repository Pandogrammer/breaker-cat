using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour
{
    private readonly string scene = "CinematicScene";
    [SerializeField] private Button playButton;
    [SerializeField] private MusicGameController musicGameController;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Canvas creditsScreen;
    [SerializeField] private Button canvasClick;


    private void Awake()
    {
        musicGameController.PlayMusic += PlayMusic;
        playButton.onClick.AddListener(StartGame);
        creditsButton.onClick.AddListener(ShowCredits);
        canvasClick.onClick.AddListener(HideCredits);
    }

    private void HideCredits()
    {
        creditsScreen.gameObject.SetActive(false);
    }

    private void ShowCredits()
    {
        creditsScreen.gameObject.SetActive(true);
    }

    private void PlayMusic()
    {
        musicGameController.PlayMenuMusic();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(scene);
    }
}