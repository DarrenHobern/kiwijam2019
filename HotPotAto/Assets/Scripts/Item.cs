using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    [SerializeField] private Ingredient ingredient;

    private bool held = false;

    private Rigidbody rb;
    public Rigidbody Rb { get { return this.rb; }}
    private SpriteRenderer spriteRenderer;
    private Collider[] cols;

    private void Awake() {
        this.rb = GetComponent<Rigidbody>();
        this.cols = GetComponentsInChildren<Collider>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (ingredient != null) {
            spriteRenderer.sprite = ingredient.S;
        }
    }

    public Ingredient GetIngredient() {
        return this.ingredient;
    }

    public void SetIngredient(Ingredient i) {
        if (i == null) {
            return;
        }
        this.ingredient = i;
        spriteRenderer.sprite = i.S;
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
