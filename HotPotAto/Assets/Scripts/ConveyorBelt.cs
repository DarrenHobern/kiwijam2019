using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Material converyerMaterial;
    [SerializeField] private Vector2 scrollSpeed;

    void Update()
    {
        Vector2 newOffset = converyerMaterial.GetTextureOffset("_MainTex");
        newOffset += scrollSpeed * Time.deltaTime;
        converyerMaterial.SetTextureOffset("_MainTex", newOffset);
    }

    private void OnCollisionStay(Collision other) {
        //Debug.Log("Item On Conveyor");
        Item i = other.gameObject.GetComponent<Item>();
        if (i != null) {
            Rigidbody otherRb = other.rigidbody;
            Vector3 force = new Vector3(scrollSpeed.x, 0, -scrollSpeed.y) * 2.48f;
            otherRb.velocity = force;
        }
    }

}
