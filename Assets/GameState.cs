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
            uiController.SetTimer(Mathf.CeilToInt(doomsday));
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