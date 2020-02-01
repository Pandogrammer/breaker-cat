using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public event Action OnActionFinished;

    public Animator animator;

    public void TeleportTo(Vector3 position, Vector3 forward)
    {
        animator.SetTrigger("Hit");

        transform.position = position;
        transform.forward = forward;
        StartCoroutine(TeleportTimer());
    }

    IEnumerator TeleportTimer()
    {
        yield return new WaitForSeconds(3f);
        OnActionFinished?.Invoke();
    }
}
