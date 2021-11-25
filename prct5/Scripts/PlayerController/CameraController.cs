using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
    }
    public float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
      mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
      mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
      mouseY = Mathf.Clamp(mouseY, -35, 30);

      transform.LookAt(Target);

      Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
      Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}