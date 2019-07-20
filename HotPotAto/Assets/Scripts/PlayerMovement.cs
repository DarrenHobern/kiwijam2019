using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Controls controls;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float maxSpeed = 2f;
    [SerializeField] private int health = 100;
    [SerializeField] private Transform holdTransform;
    [SerializeField] private GameObject spriteObj;
    [SerializeField] private Vector3 throwForce;

    private Item heldItem = null;
    private Crockpot crockpot = null;
    private Rigidbody rb;
    private Animator anim;
   
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        if (this.holdTransform == null) {
            Debug.LogError("HoldTransform not set");
        }
    }

    private void Update() {
        ControlUpdate();
        AnimationUpdate();
    }

    private void ControlUpdate() {
        float horizontal = Input.GetAxis(controls.Horizontal);
        float vertical = Input.GetAxis(controls.Vertical);
        float throwAction = Input.GetAxis(controls.ThrowAction);

        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f)) {
            rb.AddForce(horizontal * moveSpeed, 0.0f, vertical * moveSpeed, ForceMode.VelocityChange);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        

        if (throwAction > Mathf.Epsilon) {
            ThrowItem();
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
        item.Hold();
        heldItem.transform.localPosition = holdTransform.localPosition;
        heldItem.transform.SetParent(holdTransform, false);

    }

    private void ThrowItem() {
        if (heldItem == null && crockpot == null) {
            return;
        }
        // Check if held item is the pot
        if (crockpot != null) {
            // Throwing the pot will always land on the other player
            // TODO throw pot
        } else {
            // Throw the ingredient in front of you
            Debug.Log("throw item");
            heldItem.Drop();
            heldItem.transform.parent = null;
            heldItem.Rb.AddForce(throwForce, ForceMode.Impulse);
        }
    }

    // Catch items
    private void OnTriggerEnter(Collider other) {
        // TODO catching pot logic
        if (other.CompareTag("Crockpot")) {
            other.GetComponent<Crockpot>();
        } else if (other.CompareTag("Ingredient")) {
            // if the item you're catching is an ingredient and you're holding a pot then add the item to the pot
            if (crockpot) {
                // Check the item is in the recipe
            }
        }
    }

    private void CatchItem(Item item) {

    }

    private void AnimationUpdate() {
        if (heldItem != null) {
            if (heldItem.CompareTag("Pot")) {
                anim.SetBool("HoldingPot", true);
            }
            anim.SetBool("HoldingItem", true);
        } else {
            anim.SetBool("HoldingItem", false);
        }
        if (rb.velocity.magnitude > 0.1f) {
            anim.SetFloat("velocity", 1);
            if (rb.velocity.x > 0.1f) {
            spriteObj.transform.localScale = new Vector3 (1, 1, 1);
            } else if (rb.velocity.x < -0.1f) {
            spriteObj.transform.localScale = new Vector3 (-1, 1, 1);
            }
        } else {
            anim.SetFloat("velocity", 0);
        }
    }

}
