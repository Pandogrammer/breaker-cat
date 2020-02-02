using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrekeablesRandomInstantiator : MonoBehaviour
{
    public int instanceQuantities=2;
    private BrekeableInstantiatorPlaceholder[] instantiators;
    public List<BreakableObject> prefabs;
    public CatTeleporter catTeleporter;
    private int prefabNumber=0;
    private List<BreakableObject> instantiatedObjects;
    public List<BreakableObject> _prefabsRandom;

    public event Action<List<BreakableObject>> OnObjectsInstantiate;

    private void Awake()
    {
        _prefabsRandom = new List<BreakableObject>(prefabs);
        instantiatedObjects = new List<BreakableObject>();
        instantiators = GetComponentsInChildren<BrekeableInstantiatorPlaceholder>();
    }

    private void Start()
    {
        Instantiate();
        OnObjectsInstantiate?.Invoke(instantiatedObjects);
    }

    private void Instantiate()
    {
        var randomInstances=instantiators
            .OrderBy(brekeable => UnityEngine.Random.Range(0,instantiators.Length))
            .Take(instanceQuantities).ToList();
        randomInstances.ForEach(instance => {
            var brekeable=InstantiateInPosition(instance);
            instantiatedObjects.Add(brekeable);
            instance.transform.position -= instance.transform.forward * brekeable.catDistance;
            catTeleporter.AddPoint(instance);
        });
        catTeleporter.StartTeleportation();
    }

    private BreakableObject InstantiateInPosition(BrekeableInstantiatorPlaceholder instance)
    {
        var randomNum = UnityEngine.Random.Range(0, _prefabsRandom.Count) % _prefabsRandom.Count;
        var prefab = _prefabsRandom[randomNum];
        _prefabsRandom.RemoveAt(randomNum);
        var pos = instance.transform.position;
        return GameObject.Instantiate<BreakableObject>(prefab, pos, Quaternion.identity, transform);
    }
}
