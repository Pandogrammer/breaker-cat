using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private int score;
    private List<BreakableObject> objects;
    private UIController uiController;

    void Awake()
    {
        uiController = FindObjectOfType<UIController>();
        objects = FindObjectsOfType<BreakableObject>().ToList();
        objects.ForEach(SubscribeToScore);
        
        uiController.Setup(objects.Count);
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