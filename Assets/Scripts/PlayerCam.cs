using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }
    private void Update()
    {
        // fare giri�lerini alma
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);// a�a�� yukar� bak��� 90 derecede sabitleme

        //kameray� �evirme
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation= Quaternion.Euler(0,yRotation,0);
    }
}
