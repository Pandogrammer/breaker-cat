using System.Collections;
using System.Diagnostics;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BrokenObject : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    public Transform healthyObject;
    public float force = 20;
    public float minDistantce = 1f;
    public float rangeTimer = 3f;
    public float smokeRangeTimer = 5f;
    public GameObject smoke;
    public Transform brokenPieces;

    private float timeToBreak = 0f;
    private float smokeTimer = 0f;
    bool activated;
    bool onFixed;
    public States state = States.Healthy;

    private void Awake()
    {
        state = States.Start;
    }

    private void Update()
    {
        OnCrash();
        StartFixAnimation();
        FixAnimation();
    }

    public void OnPieceTouchFloor(Vector3 collisionPoint)
    {
        if (state != States.Start)
            return;
        healthyObject.gameObject.SetActive(false);
        brokenPieces.transform.position = healthyObject.transform.position;

        foreach (var piece in rigidbodies)
        {
            var dir = piece.transform.position - collisionPoint;
            piece.gameObject.SetActive(true);
            piece.AddForce(dir * force, ForceMode.Impulse);
        }
        state = States.Drop;
    }

    private void OnCrash()
    {
        if (state != States.Crash)
            return;
        
        timeToBreak += Time.deltaTime;
        if (timeToBreak > rangeTimer)
            state = States.Broken;
    }

    private void StartFixAnimation()
    {
        if(state != States.Broken)
            return;
        
        var sum = rigidbodies.Aggregate(Vector3.zero, (current, piece) => current + piece.transform.position) / rigidbodies.Length;
        if (rigidbodies.All(piece => Vector3.Distance(sum, piece.transform.position) < minDistantce))
        {
            gameObject.transform.position = sum;
            state = States.Fixed;
            smoke.SetActive(true);
            foreach (var piece in rigidbodies)
            {
                piece.gameObject.SetActive(false);
            }
        }
    }

    private void FixAnimation()
    {
        if(state != States.Fixed)
            return;
        
        smokeTimer += Time.deltaTime;
        if (smokeTimer > smokeRangeTimer)
        {
            gameObject.transform.rotation = Quaternion.identity;
            healthyObject.gameObject.SetActive(true);
            state = States.Healthy;
        }
    }
}
