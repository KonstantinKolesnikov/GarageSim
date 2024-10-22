using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutItem : MonoBehaviour, IInteractable
{
    public Transform PutItemPoint;
    public PlayerHold player;
    public void OnInteract()
    {
        if (player.IsHolding())
        {
            Transform item = player.Put();
            item.position = PutItemPoint.position;
            item.parent = null;
            item.GetComponent<BoxCollider>().enabled = true;
            item.GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
