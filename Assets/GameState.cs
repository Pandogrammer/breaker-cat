using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private UIController uiController;
    private List<BreakableObject> objects;

    [SerializeField] private float doomsday = 10;
    private int score;

    void Awake()
    {
        uiController = FindObjectOfType<UIController>();
        objects = FindObjectsOfType<BreakableObject>().ToList();
        objects.ForEach(SubscribeToScore);
        uiController.Setup(objects.Count, (int)doomsday);
    }

    void Update()
    {
        CheckDoomsday();
    }

    private void CheckDoomsday()
    {
        if(doomsday > 0){
            doomsday -= Time.deltaTime;
            if(doomsday >= 5) {
                uiController.SetTimer(Mathf.FloorToInt(doomsday));
            }
            else
            {
                uiController.SetEndingTimer((float) Math.Round(doomsday, 1));
            }
            return;
        }

        if (score == objects.Count)
        {
            uiController.ShowWin();
        }
        else
        {
            uiController.ShowLose();
        }
    }

    private void SubscribeToScore(BreakableObject obj)
    {
        obj.ObjectRepaired += AddScore;
    }

    private void AddScore()
    {
        score++;
        uiController.SetScore(score);
    }
}