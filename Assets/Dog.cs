using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void StartGame()
    {
        animator.SetTrigger("CameraCloseUp");
    }
}
