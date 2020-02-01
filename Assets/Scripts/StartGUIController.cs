using System;
using UnityEngine;
using UnityEngine.UI;

public class StartGUIController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    
    public event Action OnStartButtonClicked;
    void Awake()
    {
        startButton.onClick.AddListener(() => OnStartButtonClicked());
    }
}
