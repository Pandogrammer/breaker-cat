using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCollection : MonoBehaviour
{
    [SerializeField] private int rayLength = 2;
    [SerializeField] private LayerMask layerMaskInteract;
    private float distance;
    private Rigidbody pieceBody;

    void Update()
    {
        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            var piece = hit.collider.gameObject;
            if (Input.GetButtonDown("Fire1"))
            {
                pieceBody = piece.GetComponent<Rigidbody>();
                distance = (hit.point - piece.transform.position).magnitude;
            }

            if (Input.GetButton("Fire1"))
            {
                pieceBody.velocity = Vector3.zero;
                pieceBody.angularVelocity = Vector3.zero;
                pieceBody.MovePosition(transform.position + transform.forward * (distance + 1.5f));
                pieceBody.MoveRotation(transform.rotation);
            }
        }
    }
}