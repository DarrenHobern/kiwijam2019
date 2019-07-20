using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    private bool held = false;

    private Rigidbody rb;
    private Collider col;

    private void Awake() {
        this.rb = GetComponent<Rigidbody>();
        this.col = GetComponent<Collider>();
    }

    public void EnterHeldState() {
        if (held) {
            return;
        }
        held = true;
        col.enabled = false;
        rb.useGravity = false;
    }

    public void ExitHeldState() {
        if (!held) {
            return;
        }
        held = false;
        col.enabled = true;
        rb.useGravity = true;
    }
}
