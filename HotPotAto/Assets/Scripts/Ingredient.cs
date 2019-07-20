using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ingredient : MonoBehaviour
{
    private bool held = false;

    private Rigidbody rb;
    public Rigidbody Rb { get { return this.rb; }}
    private Collider[] cols;

    private void Awake() {
        this.rb = GetComponent<Rigidbody>();
        this.cols = GetComponentsInChildren<Collider>();
    }

    public void EnterHeldState() {
        if (held) {
            return;
        }
        held = true;
        foreach(Collider c in cols) {
            c.enabled = false;
        }
        rb.isKinematic = true;
    }

    public void ExitHeldState() {
        if (!held) {
            return;
        }
        held = false;
        foreach(Collider c in cols) {
            c.enabled = true;
        }
        rb.isKinematic = false;
    }
}
