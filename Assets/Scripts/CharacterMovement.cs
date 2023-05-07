using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    [SerializeField] Rigidbody body;
    Vector3 moveDirection;
    const float speed = 1f;

    void FixedUpdate() {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        body.AddForce(moveDirection.normalized * speed, ForceMode.VelocityChange);
    }
}
