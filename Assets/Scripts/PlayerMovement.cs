using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSmoothTime;
    public float WalkSpeed;
    public float RunSpeed;
    public KeyCode SprintKey = KeyCode.LeftShift;

    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    private Vector3 CurrentForceVelocity;
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = -0f,
            z = Input.GetAxisRaw("Vertical")
        };
 
        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKey(SprintKey) ? RunSpeed : WalkSpeed;

        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector * CurrentSpeed,
            ref MoveDampVelocity,
            MoveSmoothTime
        );
        CurrentMoveVelocity.y = -2f;

        Controller.Move(CurrentMoveVelocity * Time.deltaTime);
    }
}
