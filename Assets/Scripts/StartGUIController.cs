using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGUIController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    
    public event Action OnStartGame;
    void Awake()
    {
        startButton.onClick.AddListener(() => OnStartGame());
    }
}
