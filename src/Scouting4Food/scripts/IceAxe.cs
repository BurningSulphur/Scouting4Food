using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class IceAxe : MonoBehaviour
{
    private Item item;

    public bool breakOnCollision;

    public float minBreakVelocity;

    public GameObject instantiateOnBreak;

    public Transform instantiatePoint;

    public bool stickToNormal;

    private bool alreadyBroke;

    private void Awake()
    {
        item = GetComponent<Item>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (item.photonView.IsMine && item.itemState == ItemState.Ground && breakOnCollision && (bool)item.rig && collision.relativeVelocity.magnitude > minBreakVelocity)
        {
            Break(collision);
        }
    }

    public void Break(Collision coll)
    {
        if (!alreadyBroke)
        {
            alreadyBroke = true;
            string prefabName = "0_Items/" + instantiateOnBreak.name;
            //Quaternion rotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
            
            // Make the object's down axis (-up) point into the surface normal (made it be randomly roated but worked sorta, was facing wrong way)
            //Quaternion rotation = Quaternion.FromToRotation(Vector3.down, coll.contacts[0].normal);
            // Make the object's UP axis match the collision normal (instead of DOWN) (was rotated around y axis)
            //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, coll.contacts[0].normal);
            
            Vector3 normal = coll.contacts[0].normal;
            
            // Y axis: stick out of the surface
            Vector3 up = normal.normalized;

            // Forward direction: world up projected onto the plane of the normal
            Vector3 forward = Vector3.ProjectOnPlane(Vector3.up, up).normalized;

            // Fallback in case the normal is straight up/down and the projection vanishes
            if (forward == Vector3.zero)
                forward = Vector3.forward;

            // Build the rotation (Z = forward, Y = up)
            Quaternion rotation = Quaternion.LookRotation(forward, up);

            
            if (stickToNormal)
            {
                rotation = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);
            }
            PhotonNetwork.Instantiate(prefabName, coll.contacts[0].point, rotation, 0);
            PhotonNetwork.Destroy(base.gameObject);
        }
    }
}