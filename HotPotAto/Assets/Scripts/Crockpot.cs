using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crockpot : Holdable
{
    private List<Ingredient> ingredients = new List<Ingredient>();

    public void CatchItem(Item item) {
        if (RecipeManager.Instance.CheckItemIsInRecipe(item)) {
            Debug.Log("Catching valid item");
            ingredients.Add(item.GetIngredient());
        } else {
            // Do bad thing
        }
    }

    public void ResetIngredients() {
        ingredients.Clear();
    }

    // TODO some logic about if ingr.Length > 0 then broth. if finish then final ingredient

}
