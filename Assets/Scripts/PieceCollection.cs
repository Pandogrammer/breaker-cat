using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCollection : MonoBehaviour
{
    [SerializeField] private float rayLength = 0.1f;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float velocity = 4f;
    [SerializeField] private float distance = 0.5f;
    private Rigidbody pieceBody;
    private bool holding;

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && holding)
        {
            holding = false;
            return;
        }
           
        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.SphereCast(transform.position, radius, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            var piece = hit.collider.gameObject;
            if (Input.GetButtonDown("Fire1") && !holding)
            {
                holding = true;
                pieceBody = piece.GetComponent<Rigidbody>();
            }
        }
        if(holding)
            MoveObject();
    }

    private void MoveObject()
    {
        if (pieceBody.CompareTag("OnStartingPosition"))
            return;
        
        pieceBody.velocity = Vector3.zero;
        pieceBody.angularVelocity = Vector3.zero;
        var newPosition = Vector3.Slerp(pieceBody.transform.position,
            transform.position + transform.forward * (distance), 
            Time.deltaTime* velocity);
        pieceBody.MovePosition(newPosition);
        pieceBody.MoveRotation(new Quaternion(0, transform.rotation.y, 0, transform.rotation.w).normalized);
    }
}