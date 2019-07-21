using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientPanel : MonoBehaviour
{

    [SerializeField] private Image image;
    public void SetImage(Sprite sprite) {
        image.enabled = true;
        image.sprite = sprite;
    }
}
