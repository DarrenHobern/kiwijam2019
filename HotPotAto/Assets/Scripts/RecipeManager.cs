using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;

    [SerializeField] private Recipe[] recipes;

    private Recipe activeRecipe;

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
        Debug.Log(this.activeRecipe);
    }

    public bool CheckItemIsInRecipe(Item item) {
        return (activeRecipe.IsValidIngredient(item.GetIngredient()));
    }
}
