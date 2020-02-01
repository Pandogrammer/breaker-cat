using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameplayGUIController gameplayGUI;
    [SerializeField] private StartGUIController startGUI;
    [SerializeField] private float doomsday = 10;
    [SerializeField] private Dog dog;
    [SerializeField] private GameObject breakableObjectPrefab;
    
    private List<BreakableObject> objects;
    private int score;
    private bool playing;

    void Awake()
    {
        startGUI.OnStartButtonClicked += StartButtonClicked;
        dog.OnGameStarted += StartGame;
    }

    private void StartGame()
    {
        InstantiateBreakableObjects();
        objects = FindObjectsOfType<BreakableObject>().ToList();
        objects.ForEach(SubscribeToScore);
        gameplayGUI.Setup(objects.Count, (int)doomsday);
        playing = true;
        gameplayGUI.gameObject.SetActive(true);
    }

    private void InstantiateBreakableObjects()
    {
        var position1 = new Vector3(-4f, 6, 0);
        Instantiate(breakableObjectPrefab, position1, Quaternion.identity);
        var position2 = new Vector3(0, 3, 0);
        Instantiate(breakableObjectPrefab, position2, Quaternion.identity);
    }

    private void StartButtonClicked()
    {
        startGUI.gameObject.SetActive(false);
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
            gameplayGUI.ShowWin();
        }
    }

    private void CheckDoomsday()
    {
        if(doomsday > 0){
            doomsday -= Time.deltaTime;
            if(doomsday >= 5) {
                gameplayGUI.SetTimer(Mathf.FloorToInt(doomsday));
            }
            else
            {
                gameplayGUI.SetEndingTimer((float) Math.Round(doomsday, 1));
            }
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
}