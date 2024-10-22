using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour, IInteractable
{
    public Transform HoldItemPoint;
    public PlayerHold player;
    public void OnInteract()
    {
        if (!player.IsHolding())
        {
            player.Pick(transform);
            transform.position = HoldItemPoint.position;
            transform.SetParent(HoldItemPoint.transform, true);
            transform.GetComponent<BoxCollider>().enabled = false;
            transform.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
