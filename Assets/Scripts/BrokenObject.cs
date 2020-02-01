using System.Linq;
using UnityEngine;

public class BrokenObject : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    public Transform healthyObject;
    public float force = 20;
    bool activated;
    bool onFixed;
    public float minDistantce = 10f;
    private float timer = 0f;
    private float smokeTimer = 0f;
    public float rangeTimer = 3f;
    public float smokeRangeTimer = 5f;
    public GameObject smoke;
    
    private void Update()
    {
        
        if (activated)
        {
            timer += Time.deltaTime;
            if (timer > rangeTimer)
            {
                StartFixAnimation();
            }
        }

        if (onFixed)
        {
            FixAnimation();
        }
    }

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

    private void StartFixAnimation()
    {
        var sum = rigidbodies.Aggregate(Vector3.zero, (current, piece) => current + piece.transform.position);
        if (rigidbodies.All(piece => Vector3.Distance(sum, piece.transform.position) < minDistantce))
        {
            gameObject.transform.position = sum;
            onFixed = true;
            smoke.SetActive(true);
            foreach (var piece in rigidbodies)
            {
                piece.gameObject.SetActive(false);
            }
        }
    }

    private void FixAnimation()
    {
        smokeTimer += Time.deltaTime;
        if (smokeTimer > smokeRangeTimer)
        {
            gameObject.transform.rotation = Quaternion.identity;
            healthyObject.gameObject.SetActive(true);
            smoke.SetActive(false);
        }
    }
}
