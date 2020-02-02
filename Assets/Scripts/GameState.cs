using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameplayGUIController gameplayGUI;
    [SerializeField] private float doomsday = 10;
    [SerializeField] private Dog dog;
    [SerializeField] private BrekeablesRandomInstantiator instantiator;
    
    private List<BreakableObject> objects;
    private int score;
    private bool playing;
    private MusicGameController musicGameControllerController;


    void Awake()
    {
        StartButtonClicked();
        GetIntroMusicGame();
        instantiator.OnObjectsInstantiate += SubscribeObjects;
        dog.OnGameStarted += StartGame;
    }

    private void SubscribeObjects(List<BreakableObject> obj)
    {
        objects = obj;
        objects.ForEach(SubscribeToScore);
    }

    private void StartGame()
    {
        PlayGameMusic();
        gameplayGUI.Setup(objects.Count, (int)doomsday);
        playing = true;
        gameplayGUI.ShowCrosshair();
        gameplayGUI.gameObject.SetActive(true);
    }

    private void StartButtonClicked()
    {
        dog.StartGame();
    }

    void Update()
    {
        if (!playing)
            return;
        
        CheckDoomsday();
        CheckVictory();
        CheckDefeat();
    }

    private void CheckDefeat()
    {
        if (doomsday < 0)
        {
            dog.DisableControls();
            playing = false;
            gameplayGUI.ShowLose();
        }
    }

    private void CheckVictory()
    {
        if (score == objects.Count)
        {
            dog.DisableControls();
            playing = false;
            gameplayGUI.ShowWin(Mathf.FloorToInt(doomsday));
        }
    }

    private void CheckDoomsday()
    {
        if(doomsday > 0){
            doomsday -= Time.deltaTime;
            gameplayGUI.SetTimer(Mathf.FloorToInt(doomsday));
        }
    }

    private void SubscribeToScore(BreakableObject obj)
    {
        obj.ObjectRepaired += AddScore;
    }

    private void AddScore()
    {
        score++;
        gameplayGUI.SetScore(score);
    }
    
    private void GetIntroMusicGame()
    {
        musicGameControllerController = FindObjectOfType<MusicGameController>();
        musicGameControllerController.SetAudioSource(FindObjectOfType<AudioSource>());
    }

    private void PlayGameMusic()
    {
        musicGameControllerController.PlayGameMusic();
    }
}