using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Transform cameraTransform;
    CharacterController characterController = null;
    public float jumpSpeed = 10.0f;
    float yVelocity = 0.0f;
    public float gravity = -20.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(x, 0, z);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        Vector3 moveVelocity = moveDirection * moveSpeed;

        //transform.position += moveVelocity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpSpeed;
        }
        yVelocity += gravity * Time.deltaTime;
        moveDirection.y = yVelocity;
        moveVelocity = moveDirection * moveSpeed;
        characterController.Move(moveVelocity * Time.deltaTime);

    }
}
