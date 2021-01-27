using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target, Player;

    public float rotateSpeed = 1;

    private float mouseX, mouseY;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void LateUpdate()
    {
        mouseX += (Input.GetAxis("Mouse X")  * rotateSpeed);
        mouseY -= (Input.GetAxis("Mouse Y") * rotateSpeed);

        mouseY = Mathf.Clamp(mouseY, -35, 60);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);

    }
}
