using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : ScriptableObject
{
    [SerializeField] private Ingredient[] ingredients;
    public Ingredient[] Ingredients { get {return this.ingredients; }}

}
