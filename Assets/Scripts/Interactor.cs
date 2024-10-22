using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void OnInteract();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractorRange;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractorRange)) {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.OnInteract();
                }
            }
        }
    }
}
