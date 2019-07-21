using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;

    [SerializeField] private Animator screenAnimator;

    [SerializeField] private Recipe[] recipes;
    [SerializeField] private IngredientPanel[] ingredientPanels;

    [SerializeField] private Image currentRecipeImage;

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
        int numberOfIngredients = Mathf.Clamp(ingredients.Length, 0, 6);
        for (int i = 0; i < numberOfIngredients; i++) {
            ingredientPanels[i].ShowImage(ingredients[i].S);
        }
        return CheckRecipeComplete(new HashSet<Ingredient>(ingredients));
    }

    public void CheckItemIsInRecipe(Item item) {
        if (activeRecipe.IsValidIngredient(item.GetIngredient())) {
            screenAnimator.StopPlayback();
            screenAnimator.Play("CorrectItem", 0, 0f);
        } else {
            screenAnimator.StopPlayback();
            screenAnimator.Play("WrongItem", 0, 0f);
        }
    }

    private void SetUpIngredientPanels() {
        currentRecipeImage.sprite = activeRecipe.ResultItem.S;
        currentRecipeImage.enabled = true;
        for (int i = 0; i < ingredientPanels.Length; i++) {
            if(i < activeRecipe.Ingredients.Length) {
                ingredientPanels[i].SetEnabled();
                continue;
            }
            ingredientPanels[i].SetDisabled();
        }
    }

    private bool CheckRecipeComplete(HashSet<Ingredient> ingredients) {
        if (ingredients.Count == activeRecipe.Ingredients.Length) {
            // we done
            Recipe r = activeRecipe;
            NewRecipe();
            if (ingredients.SetEquals(r.Ingredients)) {
                // Do correct recipe things
                GameController.Instance.HealPlayers(ingredients.Count);
            }
            return true;    
        }
        return false;
    }

}
