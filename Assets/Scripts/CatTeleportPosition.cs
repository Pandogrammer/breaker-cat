using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTeleportPosition : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.3f);
        //Gizmos.DrawFrustum(transform.position, 30, 1, 0, 1);
        //Gizmos.DrawLine(transform.position, (transform.position + transform.forward * 0.5f));
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
