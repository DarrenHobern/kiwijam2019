using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMaterialUV : MonoBehaviour
{

    [SerializeField] private Material materialToScroll;
    [SerializeField] private Vector2 scrollSpeed;
    // Start is called before the first frame update
    void Update()
    {
        Vector2 newOffset = materialToScroll.GetTextureOffset("_MainTex");
        newOffset += scrollSpeed * Time.deltaTime;
        materialToScroll.SetTextureOffset("_MainTex", newOffset);
    }
}
