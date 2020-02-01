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
    public float minDistantce = 10f;
    public float rangeTimer = 3f;
    public float smokeRangeTimer = 5f;
    public GameObject smoke;

    private float timeToBreak = 0f;
    private float smokeTimer = 0f;
    bool activated;
    bool onFixed;
    private States state = States.Healthy;

    private void Awake()
    {
        state = States.Drop;
    }

    private void Update()
    {
        Debug.Log("state: " + state);
        OnCrash();
        StartFixAnimation();
        FixAnimation();
    }

    public void OnPieceTouchFloor(Vector3 collidePoint)
    {
        if (state != States.Drop)
            return;
        
        foreach (var piece in rigidbodies)
        {
            var dir = piece.transform.position - collidePoint;
            Debug.Log(dir);
            piece.AddForce(dir * force, ForceMode.Impulse);
        }
        state = States.Crash;
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
        
        var sum = rigidbodies.Aggregate(Vector3.zero, (current, piece) => current + piece.transform.position);
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
            smoke.SetActive(false);
            state = States.Healthy;
        }
    }
}
