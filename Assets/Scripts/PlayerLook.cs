using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform PlayerCamera;
    public Vector2 Sensivities;

    private Vector2 XYRotation;

    void Start()
    {
        XYRotation.x = PlayerCamera.localEulerAngles.x;
        XYRotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        Vector2 MouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };

        XYRotation.x -= MouseInput.y * Sensivities.y;
        XYRotation.y += MouseInput.x * Sensivities.x;

        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);
    }
}