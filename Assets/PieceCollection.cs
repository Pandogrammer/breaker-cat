﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCollection : MonoBehaviour
{
    [SerializeField] private float rayLength = 0.1f;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private float radius = 1f;
    private float distance;
    private Rigidbody pieceBody;
    private bool holding;

    void Update()
    {
        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.SphereCast(transform.position, radius, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            var piece = hit.collider.gameObject;
            if (Input.GetButtonDown("Fire1"))
            {
                holding = !holding;
                pieceBody = piece.GetComponent<Rigidbody>();
                distance = (hit.point - piece.transform.position).magnitude;
            }
        }
        if(holding)
            MoveObject();
    }

    private void MoveObject()
    {
        pieceBody.velocity = Vector3.zero;
        pieceBody.angularVelocity = Vector3.zero;
        pieceBody.MovePosition(transform.position + transform.forward * (distance + 1.5f));
        pieceBody.MoveRotation(transform.rotation);
    }
}