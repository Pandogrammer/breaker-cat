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
    
    private List<BreakableObject> objects;
    private int score;

    void Awake()
    {
        objects = FindObjectsOfType<BreakableObject>().ToList();
        objects.ForEach(SubscribeToScore);
        gameplayGUI.Setup(objects.Count, (int)doomsday);

        startGUI.OnStartGame += StartGame;
    }

    private void StartGame()
    {
        startGUI.gameObject.SetActive(false);
        dog.StartGame();
    }

    void Update()
    {
        CheckDoomsday();
        CheckVictory();
        CheckDefeat();
    }

    private void CheckDefeat()
    {
        if (doomsday < 0)
        {
            gameplayGUI.ShowLose();
        }
    }

    private void CheckVictory()
    {
        if (score == objects.Count)
        {
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