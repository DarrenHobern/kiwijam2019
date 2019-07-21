using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Holdable : MonoBehaviour
{
    protected bool held;
    protected Rigidbody rb;
    public Rigidbody Rb { get {return this.rb; } }
    protected Collider[] colliders;

    private void Awake() {
        this.rb = GetComponent<Rigidbody>();
        this.colliders = GetComponentsInChildren<Collider>();
        Debug.Assert(rb != null, "set rigidbody on item");
    }

    public void Hold() {
        if (this.held) {
            return;
        }
        if (this.colliders != null) {
            foreach(Collider c in this.colliders) {
                c.enabled = false;
            }
        }
        if (this.rb != null) {
            this.rb.isKinematic = true;
        }
        this.held = true;
    }

    public void Drop() {
        if (!this.held) {
            return;
        }
        transform.parent = null;
        if (this.colliders != null) {
            foreach(Collider c in this.colliders) {
                c.enabled = true;
            }
        }
        if (this.rb != null) {
            this.rb.isKinematic = false;
        }
        this.held = false;
    }
    
}
