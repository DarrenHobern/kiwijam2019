using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Controls controls;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float maxSpeed = 2f;
    [SerializeField] private float health = 100;
    public delegate void HealthChangeDelegate();
    public event HealthChangeDelegate OnHealthChange;
    [SerializeField] private Transform holdTransform;
    [SerializeField] private GameObject spriteObj;
    [SerializeField] private Vector3 throwForce;

    private int direction = 1; // -1 = facing left 1 = facing right

    private Holdable heldItem = null;
    private Rigidbody rb;
    private Animator anim;
    private bool throwing = false;
   
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        if (this.holdTransform == null) {
            Debug.LogError("HoldTransform not set");
        }
    }

    private void Update() {
        if (heldItem is Crockpot) {
            SetHealth(this.health - 5 * Time.deltaTime); // Health depletes at a rate of 10 per second
        }
        if(!throwing) {
            ControlUpdate();
        }
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
            //ThrowItem();
            if (heldItem != null) {
                anim.Play("ThrowItem", 0);
                throwing = true;
            }
        }
    }

    public float GetHealth() {
        return this.health/100;
    }

    public void SetHealth(float value) {
        this.health = value;
        OnHealthChange();
    }

    // Pickup items
    private void OnTriggerStay(Collider other) {
        float pickup = Input.GetAxis(controls.PickupAction);
        if (pickup > Mathf.Epsilon) {
            Holdable i = other.gameObject.GetComponent<Holdable>();
            if (i != null) {
                PickupItem(i);        
            }
        }
    }

    private void PickupItem(Holdable item) {
        if (heldItem != null) {
            // Fail to pickup item
            return;
        }
        if (item is Crockpot) {
            anim.SetBool("HoldingPot", true);
        } else {
            anim.SetBool("HoldingItem", true);
        }
        Debug.Log("Picked up " + item.name);
        heldItem = item;
        item.Hold();
        heldItem.transform.SetPositionAndRotation(holdTransform.localPosition, holdTransform.localRotation);
        heldItem.transform.SetParent(holdTransform, false);
    }

    private void ThrowItem() {
        if (heldItem == null) {
            return;
        }
        anim.SetBool("HoldingPot", false);
        anim.SetBool("HoldingItem", false);
        heldItem.Drop();

        // Check if held item is the pot
        if (heldItem is Crockpot) {
            // Throw pot
            Vector3 otherPosition = GameController.Instance.GetOtherPlayer(this).transform.position;
            heldItem.Rb.AddForce(
                throwForce.x * direction,
                throwForce.y,
                (otherPosition.z - transform.position.z) * throwForce.z,
                ForceMode.Impulse
            );
            
        } else if (heldItem is Item) {
            // Throw the ingredient in front of you
            heldItem.Rb.AddForce(
                throwForce.x * direction,
                throwForce.y,
                0,
                ForceMode.Impulse
            );
        }
        heldItem = null;
        throwing = false;
        // TODO return to idle
    }

    // Catch items
    private void OnTriggerEnter(Collider other) {
        if (heldItem is Item) {
            return;
        }

        if (heldItem is Crockpot) {
            Crockpot pot = heldItem as Crockpot;
            Item caught = other.gameObject.GetComponent<Item>();
            if (caught != null) {
                pot.CatchItem(caught);
            }
            Destroy(other.gameObject);
        }
    }

    private void AnimationUpdate() {
        if (rb.velocity.magnitude > 0.1f) {
            anim.SetFloat("velocity", 1);
            if (rb.velocity.x > 0.1f) {
                spriteObj.transform.rotation = Quaternion.Euler(35, 0, 0);
                direction = 1;
                // spriteObj.transform.localScale = new Vector3 (1, 1, 1);
            } else if (rb.velocity.x < -0.1f) {
                spriteObj.transform.rotation = Quaternion.Euler(-35, 180, 0);
                direction = -1;
                // spriteObj.transform.localScale = new Vector3 (-1, 1, 1);
            }
        } else {
            anim.SetFloat("velocity", 0);
        }
    }


}
