﻿using System.Collections;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    [SerializeField] private Ingredient[] ingredients;
    public Ingredient[] Ingredients { get; }

    [SerializeField] private Ingredient resultItem;
    public Ingredient ResultItem { get; }

    public bool IsValidIngredient(Ingredient i) {
        return this.ingredients.Contains(i);
    }

}
