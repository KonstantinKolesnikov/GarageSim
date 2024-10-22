using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRestriction : MonoBehaviour
{
    public Transform Center;
    public float Radius;
    private CharacterController Controller;
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        Vector3 toCenter = Center.position - transform.position;
        float distance = toCenter.magnitude;
        if (distance > Radius)
        {
            Vector3 moveDirection = Vector3.Project(Controller.velocity, toCenter.normalized);
            moveDirection.x *= 1.1f;
            moveDirection.y = 0f;
            moveDirection.z *= 1.1f;
            Controller.Move(-moveDirection * Time.deltaTime);
        }
    }
}
