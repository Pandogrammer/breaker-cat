using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour
{
    private readonly string scene = "MovementScene";
    private AudioSource audioSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
        CreateAudioSource();
    }

    private void CreateAudioSource()
    {
        var newAudioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
        newAudioSource.loop = true;
        audioSource = newAudioSource;
    }

    private void Start()
    {
        Play();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(scene);
    }
    
    void Play()
    {
        if (audioSource.isPlaying || !enabled)
            return;

        audioSource.clip = menuMusic;
        audioSource.Play();

    }
}
