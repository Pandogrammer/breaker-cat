using System.Linq;
using UnityEngine;

public class BrokenObject : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    public Transform healthyObject;
    public float force = 20;
    bool activated = false;
    public float minDistantce = 10f;
    private float timer = 0f;
    public float rangeTimer = 10f;
    
    private void Update()
    {
        
        if (activated)
        {
            timer += Time.deltaTime;
            if (timer > rangeTimer)
            {
                var sum = rigidbodies.Aggregate(Vector3.zero, (current, piece) => current + piece.transform.position);
                if (rigidbodies.All(piece => Vector3.Distance(sum, piece.transform.position)< minDistantce))
                {
                    foreach (var piece in rigidbodies)
                    {
                        piece.gameObject.SetActive(false);
                    }
                    healthyObject.gameObject.SetActive(true);
                }
            }
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
}
