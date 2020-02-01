using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;
    private List<BreakableObject> objects;
    void Start()
    {
        objects = FindObjectsOfType<BreakableObject>().ToList();
        objects.ForEach(SubscribeToScore);
    }

    private void SubscribeToScore(BreakableObject obj)
    {
        obj.ObjectRepaired += AddScore;
    }

    private void AddScore()
    {
        score++;
    }

    void Update()
    {
        scoreText.text = score + "/" + objects.Count;
    }
}
