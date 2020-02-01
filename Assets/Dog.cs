using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public event Action OnGameStarted;
    public void StartGame()
    {
        animator.SetTrigger("CameraCloseUp");
    }

    public void Update()
    {
        if (animator.GetBool("Started"))
        {
            animator.SetBool("Started", false);
            OnGameStarted();
        }
    }
}
