using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Controls controls;
    [SerializeField] private float moveSpeed = 2f;

    void Awake() {
    }

    // Update is called once per frame
    void Update() {
        controlUpdate();
    }

    void controlUpdate() {
        float horizontal = Input.GetAxis(controls.Horizontal);
        float vertical = Input.GetAxis(controls.Vertical);
        float throwAction = Input.GetAxis(controls.ThrowAction);
        float pickup = Input.GetAxis(controls.PickupAction);

        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f)) {
            transform.Translate(horizontal * moveSpeed, vertical * moveSpeed, 0.0f);
        }
    }
}
