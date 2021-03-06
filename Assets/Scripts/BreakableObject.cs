﻿using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private BrokenObject brokenObject;
    [SerializeField] private Transform placeholder;
    public float catDistance = 1f;
    public event Action ObjectRepaired;

    void Update()
    {
        if (brokenObject.state == States.Crash)
        {
            placeholder.gameObject.SetActive(true);
        }
        else if (brokenObject.state == States.BackToStartingPosition)
        {
            placeholder.gameObject.SetActive(false);
        }

        CheckDistance();
    }

    private void CheckDistance()
    {
        var distance = Vector3.Distance(brokenObject.healthyObject.position, placeholder.position);
        if (distance > 1.5f)
            return;

        if (brokenObject.state == States.Healthy)
        {
            ObjectRepaired?.Invoke();
            brokenObject.state = States.BackToStartingPosition;
            brokenObject.healthyObject.position = placeholder.position + Vector3.up*1.5f;
            brokenObject.healthyObject.rotation = placeholder.rotation;
            brokenObject.healthyObject.tag = "OnStartingPosition";
            brokenObject.tag = "OnStartingPosition";
            var rigidBody = brokenObject.healthyObject.GetComponent<Rigidbody>();
            rigidBody.constraints = RigidbodyConstraints.FreezePositionZ 
                                    | RigidbodyConstraints.FreezePositionX
                                    | RigidbodyConstraints.FreezeRotationX
                                    | RigidbodyConstraints.FreezeRotationY
                                    | RigidbodyConstraints.FreezeRotationZ;

        }
    }
}