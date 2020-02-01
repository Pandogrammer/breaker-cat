using System.Linq;
using UnityEngine;

public class PieceColliderTriggerer : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.tag=="FixedObject")
            return;
        transform.GetComponentInParent<BrokenObject>().OnPieceTouchFloor(collision.contacts.First().point);
  
    }
}
