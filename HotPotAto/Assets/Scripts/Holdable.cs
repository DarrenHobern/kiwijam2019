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
    }

    public void Hold() {
        if (this.held) {
            return;
        }
        foreach(Collider c in this.colliders) {
            c.enabled = false;
        }
        this.rb.isKinematic = true;
        this.held = true;
    }

    public void Drop() {
        if (!this.held) {
            return;
        }
        transform.parent = null;
        foreach(Collider c in this.colliders) {
            c.enabled = true;
        }
        this.rb.isKinematic = false;
        this.held = false;
    }
    
}
