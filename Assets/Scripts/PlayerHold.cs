using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHold : MonoBehaviour
{
    private Transform Item;
    private bool isHolding = false;
    public bool IsHolding() {  return isHolding; }

    public void Pick(Transform item)
    {
        isHolding = true;
        Item = item;
    }

    public Transform Put() 
    { 
        isHolding = false;
        return Item; 
    }
}
