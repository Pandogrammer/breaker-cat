using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour
{
    private readonly string scene = "CinematicScene";
    [SerializeField] private Button playButton;
    [SerializeField] private IntroMusicGame introMusicGame;

    private void Awake()
    {
        introMusicGame.PlayMusic += PlayMusic;
        playButton.onClick.AddListener(StartGame);
    }

    private void PlayMusic()
    {
        introMusicGame.Play();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(scene);
    }
}
