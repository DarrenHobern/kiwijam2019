using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;

    [SerializeField] private Recipe[] recipes;
    [SerializeField] private IngredientPanel[] ingredientPanels;

    private Recipe activeRecipe;
    public Recipe ActiveRecipe { get {return this.activeRecipe;} }

    private void Awake() {
        if (Instance == null) {
            RecipeManager.Instance = this;
        } else {
            Debug.LogWarning("Only one recipe manager can exist");
            Destroy(gameObject);
        }
    }

    public void NewRecipe() {
        this.activeRecipe = recipes[Random.Range(0, recipes.Length)];
        Debug.Log("ACtive recipe: " + this.activeRecipe.name);
        SetUpIngredientPanels();
    }

    public bool UpdateIngredients(Ingredient[] ingredients) {
        // Show any new ingredients in the UI
        for (int i = 0; i < ingredients.Length; i++) {
            ingredientPanels[i].ShowImage(ingredients[i].S);
        }
        return CheckRecipeComplete(new HashSet<Ingredient>(ingredients));
    }

    public bool CheckItemIsInRecipe(Item item) {
        return (activeRecipe.IsValidIngredient(item.GetIngredient()));
    }

    private void SetUpIngredientPanels() {
        for (int i = 0; i < ingredientPanels.Length; i++) {
            if(i < activeRecipe.Ingredients.Length) {
                ingredientPanels[i].SetEnabled();
                continue;
            }
            ingredientPanels[i].SetDisabled();
        }
    }

    private bool CheckRecipeComplete(HashSet<Ingredient> ingredients) {
        Recipe r = activeRecipe;
        NewRecipe();
        if (ingredients.SetEquals(r.Ingredients)) {
            // Do correct recipe things
            GameController.Instance.HealPlayers(ingredients.Count);
            return true;
        }
        return false;
    }

}
