using System;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private Movement movement;
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

    public void DisableControls()
    {
        mouseLook.enabled = false;
        movement.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
