using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private BrokenObject brokenObject;
    [SerializeField] private Transform placeholder;
    public event Action ObjectRepaired;
    void Update()
    {
        if (brokenObject.state == States.Drop)
        {
            placeholder.gameObject.SetActive(true);
        }
        CheckDistance();
    }

    private void CheckDistance()
    {
        var distance = Vector3.Distance(brokenObject.healthyObject.position, placeholder.position);
        if (distance > 0.5f)
            return;

        if (brokenObject.state == States.Healthy)
        {
            ObjectRepaired();
            brokenObject.state = States.OnStartingPosition;
            brokenObject.healthyObject.position = placeholder.position;
            brokenObject.healthyObject.tag = "OnStartingPosition";
            brokenObject.tag = "OnStartingPosition";
        }
    }
}
