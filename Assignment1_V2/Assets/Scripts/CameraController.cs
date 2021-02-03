using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player,target;
    public float rotationSpeed;


    private float mouseX, mouseY;

    void Start(){

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



    void Update(){
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        target.transform.LookAt(player.transform);

        player.transform.rotation = Quaternion.Euler(mouseY, 0, 0);
        target.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);

    }
}

