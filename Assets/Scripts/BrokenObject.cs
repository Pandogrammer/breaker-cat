using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObject : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    public float force = 20;
    bool activated = false;

    public void OnPieceTouchFloor(Vector3 collidePoint)
    {
        if (activated)
            return;
        activated = true;
        foreach (var piece in rigidbodies)
        {
            var dir = piece.transform.position - collidePoint;
            Debug.Log(dir);
            piece.AddForce(dir * force, ForceMode.Impulse);
        }
    }
}
