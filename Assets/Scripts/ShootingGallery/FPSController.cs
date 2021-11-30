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
    public int leftClamp = 320;
    public int rightClamp = 45;
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
            if(!(rotationX > leftClamp || rotationX < rightClamp)) {
                float diff = Mathf.Abs(rotationX - leftClamp);
                //if difference of rotationX is close to 320 clamp it there else 45
                rotationX = Mathf.Abs(rotationX - leftClamp) < 40 ? (leftClamp> 0 ? leftClamp+1f:leftClamp-1f) : (rightClamp > 0 ? rightClamp-1f:rightClamp+1f);
            }
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, -60f, 60f);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}
