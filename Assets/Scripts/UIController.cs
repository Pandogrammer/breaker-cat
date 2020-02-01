using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int objectCount;

    public void SetScore(int score)
    {
        scoreText.text = string.Format("OBJECTS REPAIRED: {0}/{1}", score, objectCount);
    }

    public void Setup(int objectCount)
    {
        this.objectCount = objectCount;
        SetScore(0);
    }
}
