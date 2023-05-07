using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterMovement : NetworkBehaviour {
    [SerializeField] Rigidbody body;
    [SerializeField] GameObject cameraManager;
    Vector3 moveDirection;
    const float speed = 0.25f;
    const float rotationSpeed = 10f;

    [Client]
    void Start() {
        if (!isOwned) return;
        cameraManager = GameObject.Find("CameraManager");
    }

    [Client]
    void Update() {
        if (!isOwned) return;
        cameraManager.transform.position = transform.position;

        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.y += Input.mouseScrollDelta.y * rotationSpeed;
        transform.rotation = Quaternion.Euler(currentRotation);

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed / 2;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed / 2;

        /*Vector3 cameraRotation = cameraManager.transform.rotation.eulerAngles;
        cameraRotation.z = 0;
        cameraRotation.y -= Input.mouseScrollDelta.y * rotationSpeed;
        cameraManager.transform.rotation = Quaternion.Euler(cameraRotation);*/

        if (Input.GetMouseButton(1)) {
            Vector3 cameraRotation = cameraManager.transform.rotation.eulerAngles;
            cameraRotation.z = 0;

            cameraRotation.x -= mouseY;
            cameraRotation.y += mouseX;
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, 10, 90);

            cameraManager.transform.rotation = Quaternion.Euler(cameraRotation);
        }

        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
    }

    [Client]
    void FixedUpdate() {
        if (!isOwned) return;

        body.AddForce(moveDirection.normalized * speed, ForceMode.VelocityChange);
    }
}