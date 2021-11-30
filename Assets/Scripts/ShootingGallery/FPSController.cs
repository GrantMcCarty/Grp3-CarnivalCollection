using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 12f;
    public float sensitivityY = 12f;
    float rotationY = 0f;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Player and Camera rotation
        if (axes == RotationAxes.MouseXAndY && canMove)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            //rotation is tough here, left goes from 360 down and right goes from 0 up
            if(!(rotationX > 310 || rotationX < 48)) {
                float diff = Mathf.Abs(rotationX - 310f);
                //if difference of rotationX is close to 320 clamp it there else 45
                rotationX = Mathf.Abs(rotationX - 310f) < 40 ? 311f : 47f;
            }
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, -60f, 60f);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}
