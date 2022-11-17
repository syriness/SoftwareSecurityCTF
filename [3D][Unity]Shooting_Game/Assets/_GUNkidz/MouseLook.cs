using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitibity = 700.0f;

    float rotationX = 0;
    float rotationY = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationX += mouseMoveValueX * sensitibity * Time.deltaTime;
        rotationY += mouseMoveValueY * sensitibity * Time.deltaTime;

        rotationY = Mathf.Clamp(rotationY, -50.0f, 60.0f);

        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
    }
}
