using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        GameObject.Destroy(other.gameObject);
    }
}
