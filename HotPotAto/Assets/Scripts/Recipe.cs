using System.Collections;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    [SerializeField] private Ingredient[] ingredients;
    public Ingredient[] Ingredients { get {return this.ingredients;} }

    [SerializeField] private Ingredient resultItem;
    public Ingredient ResultItem { get {return this.resultItem;} }

    public bool IsValidIngredient(Ingredient i) {
        return this.ingredients.Contains(i);
    }

}
