using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Controls controls;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int health = 100;
    [SerializeField] private Transform holdTransform;
    private Item heldItem = null;

    [SerializeField] private Vector3 throwForce;
   
    private void Awake() {
        if (this.holdTransform == null) {
            Debug.LogError("HoldTransform not set");
        }
    }

    // Update is called once per frame
    private void Update() {
        ControlUpdate();
    }

    private void ControlUpdate() {
        float horizontal = Input.GetAxis(controls.Horizontal);
        float vertical = Input.GetAxis(controls.Vertical);
        float throwAction = Input.GetAxis(controls.ThrowAction);

        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f)) {
            transform.Translate(horizontal * moveSpeed, 0.0f, vertical * moveSpeed);
        }

    }

    // Pickup items
    private void OnTriggerStay(Collider other) {
        float pickup = Input.GetAxis(controls.PickupAction);
        Item i = other.gameObject.GetComponent<Item>();
        if (i != null) {
            if (pickup > Mathf.Epsilon) {
                PickupItem(i);
                
            }
        }
    }

    private void PickupItem(Item item) {
        if (heldItem != null) {
            // Fail to pickup item
            return;
        }

        Debug.Log("Picked up " + item.name);
        heldItem = item;
        item.EnterHeldState();
        heldItem.transform.position = holdTransform.position;
        heldItem.transform.SetParent(holdTransform, false);

    }

    private void ThrowItem() {
        if (heldItem == null) {
            return;
        }

        // Check if held item is the pot
        if (heldItem.CompareTag("Pot")) {
            // Throwing the pot will always land on the other player
        } else {
            // Throw the ingredient in front of you
            heldItem.ExitHeldState();
            heldItem.transform.parent = null;
            heldItem.Rb.AddForce(throwForce, ForceMode.Impulse);
        }
    }

}
