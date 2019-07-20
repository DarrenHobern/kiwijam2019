using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredient", order = 1)]
public class Ingredient : ScriptableObject
{
    [SerializeField] private Sprite uiSprite;
    [SerializeField] private Sprite gameSprite;
}
