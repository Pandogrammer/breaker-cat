using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public event Action OnActionFinished;

    public float animationTime = 2f;
    public float activatePushIn = 1f;
    public Transform pushCollider;
    public Animator animator;


    public void TeleportTo(Vector3 position, Vector3 forward)
    {
        animator.SetTrigger("Hit");

        transform.position = position;
        transform.forward = forward;
        StartCoroutine(TeleportTimer());
        StartCoroutine(ActivatePush());
    }

    IEnumerator ActivatePush()
    {
        yield return new WaitForSeconds(activatePushIn);
        pushCollider.gameObject.SetActive(true);
    }

    IEnumerator TeleportTimer()
    {
        yield return new WaitForSeconds(animationTime);
        pushCollider.gameObject.SetActive(false);
        OnActionFinished?.Invoke();
    }
}
