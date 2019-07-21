using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;

    [SerializeField] private Recipe[] recipes;

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
    }

    public void UpdateIngredients(Ingredient[] ingredients) {
        // TODO update UI here with the ingredients' sprites
        if (ingredients.Equals(activeRecipe.Ingredients)) {
            // TODO complete the recipe
            Debug.Log("RECIPE COMPLETE");
        }
    }

    public bool CheckItemIsInRecipe(Item item) {
        return (activeRecipe.IsValidIngredient(item.GetIngredient()));
    }
}
