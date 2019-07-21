using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Holdable
{
    [SerializeField] private Ingredient ingredient;

    private SpriteRenderer spriteRenderer;

    private void Start() {
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

}
