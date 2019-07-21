using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crockpot : Holdable
{
    private List<Ingredient> ingredients = new List<Ingredient>();

    public void CatchItem(Item item) {
        ingredients.Add(item.GetIngredient());
        if (RecipeManager.Instance.UpdateIngredients(ingredients.ToArray())) {
            ResetIngredients();
        }
    }

    public void ResetIngredients() {
        ingredients.Clear();
    }

    // TODO some logic about if ingr.Length > 0 then broth. if finish then final ingredient

    void OnDestroy() {
        GameController.Instance.GameOver();
    }
}
