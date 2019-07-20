using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;

    [SerializeField] private Recipe[] recipes;

    private void Awake() {
        if (Instance == null) {
            RecipeManager.Instance = this;
        } else {
            Debug.LogWarning("Only one recipe manager can exist");
            Destroy(gameObject);
        }
    }
}
