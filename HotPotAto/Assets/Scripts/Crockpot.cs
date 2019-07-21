using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crockpot : Holdable
{
    private List<Ingredient> ingredients = new List<Ingredient>();

    public bool CatchItem(Item item) {
        if (RecipeManager.Instance.CheckItemIsInRecipe(item)) {
            Debug.Log("Catching valid item");
            ingredients.Add(item.GetIngredient());
            if (RecipeManager.Instance.UpdateIngredients(ingredients.ToArray())) {
                ResetIngredients();
            }
            return true;
        } else {
            // Do bad thing
            return false;
        }
    }

    public void ResetIngredients() {
        ingredients.Clear();
    }

    // TODO some logic about if ingr.Length > 0 then broth. if finish then final ingredient

}
