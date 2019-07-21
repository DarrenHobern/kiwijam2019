using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientPanel : MonoBehaviour
{

    [SerializeField] private Image image;
    public void ShowImage(Sprite sprite) {
        image.enabled = true;
        image.sprite = sprite;
    }
    public void SetEnabled(){
        this.gameObject.SetActive(true);
        image.enabled = false;
    }

    public void SetDisabled(){
        this.gameObject.SetActive(false);
        image.enabled = false;
    }
}
